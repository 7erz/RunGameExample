using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] public bool state = true;
    [SerializeField] public float speed = 20;
    [SerializeField] public float limitSpeed = 50;
    
    public void GameOver()
    {
        state = false;
    }

    //�ε�ڽ��� �ε��������� 
    public void IncreaseSpeed()
    {
        if(speed < limitSpeed)
        {
            speed++;
        }
    }


}
