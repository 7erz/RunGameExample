using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static float spawnTime = 2.5f;

    public float SpawnTime
    {
        get { return spawnTime; }
        set { spawnTime = value; }
    }


    void Start()
    {
        
    }

    public void ControlLevel()
    {
        //0.075�ʾ� ���ҽ�Ŵ
        //0.25f���� �ȴٸ� ���ҵ��� ����
       if(spawnTime > 0.25f)
       {
            spawnTime -= 0.075f;
       }
        
    }
}
