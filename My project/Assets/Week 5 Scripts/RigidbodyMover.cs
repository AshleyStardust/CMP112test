using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class RigidbodyMover : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField] private float VerticalForce = 30.0f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        //Here's another way you can check for Keyboard input
        if (Keyboard.current.leftShiftKey.isPressed)
        {
            rb.AddForce(Vector3.up * VerticalForce);
        }

    }
}
