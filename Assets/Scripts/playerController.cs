using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
///  IMPORTANT NOTE:
///  
///  A player controller will always be a component on a camera
/// </summary>


public class playerController : MonoBehaviour
{
    public static playerController player; //the player controller is a singleton
    public AudioSource ambience; // used to enable and disable warehouse ambience

    private GameObject _pawn; // access using a property
    public GameObject pawn // This property ensures that whenever a new pawn is assigned, the movement reference is also updated
    {
        get => _pawn;
        set
        {
            _pawn = value;
            pawnMovement = value.GetComponent<Movement>();
        }
    }

    private Movement pawnMovement;

    public bool isHoldingBox { get; private set; } = false;

    public Action setDownBox = delegate { }; // This event works like a global event since the player is a singleton
                                             // Used for HUD updating

    // This is a component from the new input system that collects input and automatically calls functions like
    // OnSubmit, OnMove, OnMouseMove, OnExit, etc
    // The new input system also automatically supplies and inputValue argument to these functions
    public PlayerInput input; // This reference is used to alter what input state the player is in; Title | Menu | Gameplay

    
    // This property returns whether the player is in light or not
    // Perhaps this should be in the light detector, but that is not a singleton so it would be a pain to access a reference to it
    // In fact the light detector uses this property to determine if the player is in light or not, the light detector just performs the functionality for being in shadow
    public bool inLight
    {
        get
        {
            // The player can technically be within two tiles at the same time if they are standing in between the two
            // If there are no tiles that contain the player then the player must be in darkness, so this foreach loop will not execute
            foreach (GridItem gridSquare in GridItem.gridItems.Where(_gridItem => _gridItem.containsPlayer))
            {
                if (gridSquare._light.isOn) { return true; } //Early out if it found a tile that is lit
            }
            return false;
        }
    }

    private void Awake()
    {
        if (playerController.player == null ) // Singleton logic
        {
            playerController.player = this;
            Debug.Log("Player activated");
        } else
        {
            Destroy(this.gameObject);
        }

        // Initialization of player controller
        // cache component refs
        input = GetComponent<PlayerInput>();
        ambience = GetComponent<AudioSource>();
        // Bind observers to events
        pickupReceiver.pickedUpItem += BoxPickup;
        setDownBox += BoxSetdown;
    }

    private void Update()
    {
        if (_pawn != null)
        {
            // This code is for keeping the camera on the pawn at all times
            // If the camera was a child of the pawn, then when the pawn is destroyed or disabled the input will no longer be collected
            this.gameObject.transform.position = _pawn.transform.position + Vector3.up*2;
        }
        
    }


    #region InputEvents
    /// <summary>
    /// The Input events are automatically called by the input component
    /// </summary>

    public void OnMove(InputValue value)
    {
        // Update the pawn's input velocity
        Vector2 _value = value.Get<Vector2>();
        pawnMovement.velocity.x = _value.x;
        pawnMovement.velocity.z = _value.y;
    }

    public void OnMouseMove(InputValue value)
    {
        Vector2 _value = value.Get<Vector2>();
        pawnMovement.rotation = _value;

        //Only rotate the pawn horizontally
        Vector3 currentRot = pawn.gameObject.transform.localEulerAngles;
        pawn.gameObject.transform.localRotation = Quaternion.Euler(0, currentRot.y + _value.x, 0);

        //Rotate the camera horizontally and vertically
        //This is because the pawn cannot rotate vertically, so the camera must control its own local rotation
        Vector3 camRot = this.gameObject.transform.localEulerAngles;
        this.gameObject.transform.localRotation = Quaternion.Euler(camRot.x - _value.y, currentRot.y + _value.x, 0);
    }


    public void OnSubmit(InputValue inputValue) //Called from title state
    {
        GameManager.Game.SetState(gameState.Menu);
    }

    public void OnPlay(InputValue inputValue) //Called from menu state
    {
        GameManager.Game.SetState(gameState.Gameplay);
    }

    public void OnExit(InputValue inputValue) //Called from menu state
    {
        Application.Quit();
    }

    #endregion

    //These functions binded into public events during Awake so they automatically execute
    private void BoxPickup()
    {
        Debug.Log("Picked up box");
        isHoldingBox = true;
    }

    private void BoxSetdown()
    {
        Debug.Log("Set down box");
        isHoldingBox = false;
    }


}
