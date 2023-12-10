using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public static playerController player;

    private GameObject _pawn;
    private Movement pawnMovement;

    public PlayerInput input;

    public GameObject pawn
    {
        get => _pawn;
        set
        {
            _pawn = value;
            pawnMovement = value.GetComponent<Movement>();
        }
    }

    private void Awake()
    {
        if (playerController.player == null )
        {
            playerController.player = this;
            Debug.Log("Player activated");
        } else
        {
            Destroy(this.gameObject);
        }
        input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        if (_pawn != null)
        {
            this.gameObject.transform.position = _pawn.transform.position + Vector3.up*2;
        }
        
    }

    public void OnMove(InputValue value)
    {
        Vector2 _value = value.Get<Vector2>();
        pawnMovement.velocity.x = _value.x;
        pawnMovement.velocity.z = _value.y;

        Debug.Log(_value);
    }

    public void OnMouseMove(InputValue value)
    {
        Vector2 _value = value.Get<Vector2>();
        pawnMovement.rotation = _value;

        Vector3 currentRot = pawn.gameObject.transform.localEulerAngles;
        pawn.gameObject.transform.localRotation = Quaternion.Euler(0, currentRot.y + _value.x, 0);

        Vector3 camRot = this.gameObject.transform.localEulerAngles;
        this.gameObject.transform.localRotation = Quaternion.Euler(camRot.x - _value.y, currentRot.y + _value.x, 0);


        Debug.Log(_value);
    }
}
