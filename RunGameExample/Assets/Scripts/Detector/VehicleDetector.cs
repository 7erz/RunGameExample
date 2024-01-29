using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDetector : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        //collision.gameObject.GetComponent<Vehicle>().CarSpeed = car.GetComponent<Vehicle>().CarSpeed;
        Vehicle vehicle = collision.gameObject.GetComponent<Vehicle>();
        if (vehicle != null)
        {
            vehicle.CarSpeed = transform.parent.GetComponent<Vehicle>().CarSpeed;
        }

    }

    //private void OnTriggerEnter(Collider other)
    //{
    //    Vehicle vehicle = other.GetComponent<Vehicle>();

    //    if(vehicle != null)
    //    {
    //        vehicle.CarSpeed = transform.parent.GetComponent<Vehicle>().CarSpeed;
    //    }
    //}

}
