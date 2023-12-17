using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//While going through my code to comment it I'm surprised at how short the movement component is here

public class Movement : MonoBehaviour
{

    [HideInInspector] public Vector3 velocity; //these two represent inputs, so they are normalized
    [HideInInspector] public Vector2 rotation; //Also this rotation variable is not used here

    public float speed = 5f; //move speed set in inspector

    //The character controller component is a unity component similar to a rigidbody
    //It does not do physics though, however it does do collission checking so this object can't move through walls
    //Simply used _charactercontrolller.move() instead
    CharacterController _characterController;

    private void Awake() //cache the character controller component
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        //Calculating the direction to move is a bit complicated since it needs to move forward locally, and sideways locally
        //Since in an fps game the movement is tied to your camera's rotation driven by the mouse input
        Vector3 forwardVector = this.transform.forward * velocity.z * speed * Time.deltaTime;
        Vector3 sideVector = this.transform.right * velocity.x * speed * Time.deltaTime;

        _characterController.Move(forwardVector+sideVector); //this actually moves the controller
        
    }

}
