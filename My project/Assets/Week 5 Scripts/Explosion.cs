using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Explosion : MonoBehaviour
{
    [SerializeField] private float ExplosionRadius = 5f;
    [SerializeField] private float ExplosionForce = 10.0f;
    [SerializeField] private float ExplosionLift = 5.0f;

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            //Ask the physics engine for any colliders within our ExplosionRadius
            Collider[] colliderArray = Physics.OverlapSphere(transform.position, ExplosionRadius);

            //If we found at least one collider...

            if(colliderArray.Length > 0)
            {
                //Here's a new way to do a for loop!
                //Go through the array and do something to each one
                //https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/iteration-statements#the-foreach-statement
                foreach (Collider col in colliderArray)
                {
                    //Get the Rigidbody on the colliding object, if it has one
                    Rigidbody other = col.attachedRigidbody;
                    if (other != null)
                    {
                        //EXPLODE IT
                        other.AddExplosionForce(ExplosionForce, transform.position, ExplosionRadius, ExplosionLift, ForceMode.Impulse);
                    }
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, ExplosionRadius);
    }
}
