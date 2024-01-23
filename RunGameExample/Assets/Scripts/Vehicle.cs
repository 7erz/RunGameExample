using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] float carSpeed;
    [SerializeField] Vector3 carDir;

    public float CarSpeed
    {
        get { return carSpeed; }
        set { carSpeed = value; }
    }

    private void OnEnable()
    {
        carSpeed = Random.Range(5, 15);
        carDir = Vector3.forward;
    }

    private void Update()
    {
        MovingCar();
    }


    public void MovingCar()
    {
        gameObject.transform.Translate(carDir * carSpeed * Time.deltaTime);
    }

    //��� �ޱ� ��
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("�ε�����");
        }
    }*/

    public override void Activate(Runner runner)
    {
        Debug.Log("�ε�����");
    }



}
