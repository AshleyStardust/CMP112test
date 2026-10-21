using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTester : MonoBehaviour
{
    [Header("Enable Events")]
    [SerializeField] private bool printTriggerEnter = true;
    [SerializeField] private bool printTriggerExit  = true;


    private void OnTriggerEnter(Collider collider)
    {
        if (printTriggerEnter)
        {
            string output = $"My name is {name} and I have started a collision with {collider.name}.";

            Debug.Log(output);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (printTriggerExit)
        {
            string output = $"My name is {name} and I have exited a collision with {other.name}.";

            Debug.Log(output);
        }
    }
}
