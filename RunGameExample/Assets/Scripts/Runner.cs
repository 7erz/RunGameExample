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

    private void OnDisable()
    {
        InputManager.instance.keyAction -= Move;
    }
}
