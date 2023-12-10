using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    [HideInInspector] public Vector3 velocity;
    [HideInInspector] public Vector2 rotation;
    public float speed = 5f;
    CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        Vector3 forwardVector = this.transform.forward * velocity.z * speed * Time.deltaTime;
        Vector3 sideVector = this.transform.right * velocity.x * speed * Time.deltaTime;
        _characterController.Move(forwardVector+sideVector);
        
    }

}
