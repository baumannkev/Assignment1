using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player2Controller : MonoBehaviour
{
    //create private internal references
    private InputActions2 inputActions;
    private InputAction movement;
    
    Rigidbody rb;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>(); //get rigidbody, responsible for enabling collision with other colliders
        inputActions = new InputActions2(); //create new InputActions
    }
    //called when script enabled
    private void OnEnable()
    {
        movement = inputActions.Player2.Movement; //get reference to movement action
        movement.Enable();
        //create a DoJump callback function
        //DoJump automatically called when Jump binding performed
    }
//called when script disabled
    private void OnDisable()
    {
        movement.Disable();
    }
    
    //called every physics update
    private void FixedUpdate()
    {
        Vector2 v2 = movement.ReadValue<Vector2>(); //extract 2d input data
        Vector3 v3 = new Vector3(v2.x, v2.y, 0); //convert to 3d space
        //transform.Translate(v3); //moves transform, ignoring physics
        rb.AddForce(v3, ForceMode.VelocityChange); 
        //apply instantphysics force, ignoring mass
    }
}