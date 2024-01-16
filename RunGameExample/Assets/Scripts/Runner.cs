using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum RoadLine
{
    LEFT = -1,
    MIDDLE,
    RIGHT
}

public class Runner : MonoBehaviour
{
    [SerializeField] RoadLine roadLine;
    [SerializeField] float positionX;
    [SerializeField] float moveSpeed;

    private void OnEnable()
    {
        InputManager.instance.keyAction += Move;
    }
    void Start()
    {
        roadLine = RoadLine.MIDDLE;
    }

    // Update is called once per frame
    void Update()
    {
        Status();
    }

    public void Move()
    {
        //Resources.Load();
        /*
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        // 퍼즈 같은 것들을 불러올수도 있음,
        //GameObject panel = null이고, panel == null 이면 Instantiate 아니라면 SetActive
        //    Instantiate(Resources.Load<GameObject>("Runner"));      //<>안에는 가져올 것들 Image,Sprite등
        //관리가 어려움 -> ResourcesManager를 만들어 하나에 관리하는 방법이 있음
        //}*/



        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if(roadLine >RoadLine.LEFT)
            {
                roadLine--; 
            }  
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (roadLine < RoadLine.RIGHT)
            {
                roadLine++;
            }
        }
    }

    public void Status()
    {
        switch (roadLine)
        {
            case RoadLine.LEFT:
                SmoothMovement(-positionX);
                break;
            case RoadLine.RIGHT:
                SmoothMovement(positionX);
                break;
            case RoadLine.MIDDLE:
                SmoothMovement(0);
                break;
        }
    }

    public void SmoothMovement(float positionX)
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(positionX, 0, 0), Time.deltaTime * moveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        CollisionObject collisionObject = other.GetComponent<CollisionObject>();

        if(collisionObject != null)
        {
            collisionObject.Activate(this);
        }
    }

    private void OnDisable()
    {
        InputManager.instance.keyAction -= Move;
    }
}
