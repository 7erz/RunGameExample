using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCollider : MonoBehaviour
{
    [SerializeField] public bool isTriggered;

    public bool IsTriggered
    {
        get { return isTriggered; }
    }

    private void OnTriggerStay(Collider other)
    {
        Vehicle vehicle = other.GetComponent<Vehicle>();
        if (vehicle)
        {
            isTriggered = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }
}
