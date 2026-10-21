using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class CollisionTester : MonoBehaviour
{
    [Header("Enable Events")]
    [SerializeField] private bool printCollisionEnter = true;
    [SerializeField] private bool printCollisionExit = true;
    [SerializeField] private bool printCollisionStay = true;

    [Header("Enable Logging")]
    [SerializeField] private bool printPosition = false;
    [SerializeField] private bool printVelocity = false;
    [SerializeField] private bool printNormal = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (printCollisionEnter)
        {
            string output = $"My name is {name} and I have started a collision with {collision.gameObject.name}.";

            //Make sure we have a contact point because we don't necessarily have one, especially OnExit
            if (collision.contacts.Length > 0)
            {
                //We're simply looking at the first collision point here.
                //Ideally you would look at all the points of collision

                if (printPosition) output   += $"\n\tThe collision point was {collision.GetContact(0).point.ToString()}";
                if (printVelocity) output   += $"\n\tThe velocity on impact was {collision.GetContact(0).impulse.ToString()}";
                if (printNormal) output     += $"\n\tThe normal vector of the collision was {collision.GetContact(0).normal.ToString()}";

                // In case you haven't seen it before \n in a string is the New Line character
                // \t inserts a Tab into a string. They can be useful for formatting your debug messages
            }

            Debug.Log(output);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (printCollisionExit)
        {
            string output = $"My name is {name} and I have exited a collision with {collision.gameObject.name}.";

            //Make sure we have a contact point because we don't necessarily have one, especially OnExit
            if (collision.contacts.Length > 0)
            {
                //We're simply looking at the first collision point here.
                //Ideally you would look at all the points of collision
                if (printPosition) output   += $"\n\tThe collision point was {collision.GetContact(0).point.ToString()}";
                if (printVelocity) output   += $"\n\tThe velocity on separation was {collision.GetContact(0).impulse.ToString()}";
                if (printNormal) output     += $"\n\tThe normal vector of the collision was {collision.GetContact(0).normal.ToString()}";
            }
            Debug.Log(output);
        }
    }

}
