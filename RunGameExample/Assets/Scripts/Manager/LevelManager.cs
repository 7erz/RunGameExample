using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        spawnTime = 2.5f;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Time.timeScale = 1f;
    }

}
