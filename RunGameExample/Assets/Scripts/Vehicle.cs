using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : CollisionObject
{
    [SerializeField] float carSpeed;
    [SerializeField] Vector3 carDir;
    [SerializeField] AudioClip crashed;

    [SerializeField] float minRandomSpeed = 5f;
    [SerializeField] float maxRandomSpeed = 20f;


    public float CarSpeed
    {
        get { return carSpeed; }
        set { carSpeed = value; }
    }

    private void OnEnable()
    {
        if(minRandomSpeed < 19)
        {
            minRandomSpeed += 1;
        }

        carSpeed = GameManager.instance.speed + Random.Range(minRandomSpeed, maxRandomSpeed);
        carDir = Vector3.forward;
    }

    private void Update()
    {
        if(GameManager.instance.state == false)
        {
            return;
        }

        MovingCar();
    }


    public void MovingCar()
    {
        gameObject.transform.Translate(carDir * carSpeed * Time.deltaTime);
    }

    //»ó¼Ó ¹Þ±â Àü
    /*private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("ºÎµúÇûÀ½");
        }
    }*/

    public override void Activate(Runner runner)
    {
        Debug.Log("ºÎµúÇûÀ½");
        AudioManager.instance.SFXSound(crashed);
        runner.animator.Play("Die");
        GameManager.instance.GameOver();
    }



}
