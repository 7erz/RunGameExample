using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightCollider : MonoBehaviour
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
            if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                isTriggered = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        isTriggered = false;
    }
}
