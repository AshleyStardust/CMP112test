using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class KinematicMover : MonoBehaviour
{
    [SerializeField] private float MovementSpeed = 0.2f;
    

    void FixedUpdate()
    {
        Vector3 input = GetInput();
        Vector3 movement = Vector3.zero;

        //Is there user input?
        if(input.magnitude > 0.0f)
        {
            //input is which way we want to go
            //MovementSpeed is how fast
            //Time.deltaTime ensures framerate independent consistency
            movement = input * MovementSpeed;
        }

        Vector3 movementThisFrame = movement * Time.fixedDeltaTime;
        transform.Translate(movement);
    }

    /// <summary>
    /// Don't worry about what this clas is doing. 
    /// It's taking the user input on WASD, translating it relative to the camera direction, and then
    /// returning that as a Vector3.
    /// </summary>
    /// <returns></returns>
    Vector3 GetInput()
    {
        float x = (Keyboard.current.aKey.isPressed ? -1:0) + (Keyboard.current.dKey.isPressed ? 1 : 0);
        float z = (Keyboard.current.sKey.isPressed ? -1:0) + (Keyboard.current.wKey.isPressed ? 1 : 0);

        float y = (Keyboard.current.leftCtrlKey.isPressed ? -1 : 0) + (Keyboard.current.spaceKey.isPressed ? 1 : 0);

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0.0f;
        right.y = 0.0f;
        forward.Normalize();
        right.Normalize();

        return ((forward * z) + (right * x) + (Vector3.up * y)).normalized;
    }
}
