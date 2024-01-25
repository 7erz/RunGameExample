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
    public Animator animator;

    [SerializeField] public RoadLine roadLine;
    [SerializeField] float positionX;
    [SerializeField] float moveSpeed;
    [SerializeField] LeftCollider leftCollider;
    [SerializeField] RightCollider rightCollider;

    private void OnEnable()
    {
        
    }
    void Start()
    {
        roadLine = RoadLine.MIDDLE;
        InputManager.instance.keyAction += Move;
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
        // ���� ���� �͵��� �ҷ��ü��� ����,
        //GameObject panel = null�̰�, panel == null �̸� Instantiate �ƴ϶�� SetActive
        //    Instantiate(Resources.Load<GameObject>("Runner"));      //<>�ȿ��� ������ �͵� Image,Sprite��
        //������ ����� -> ResourcesManager�� ����� �ϳ��� �����ϴ� ����� ����
        //}*/

        if(GameManager.instance.state == false)
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            if (leftCollider.IsTriggered)
            {
                return;
            }

            if(roadLine >RoadLine.LEFT)
            {
                roadLine--; 
            }  
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            if (rightCollider.IsTriggered)
            {
                return;
            }
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
