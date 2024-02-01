using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : Singleton<GameManager>
{
    [Header("Default Game Settings")]
    [SerializeField] public bool state = true;
    [SerializeField] public float speed = 20;
    [SerializeField] public float limitSpeed = 50;

    [Header("Car Speed Settings")]
    [SerializeField] public float minRandomSpeed = 5f;
    [SerializeField] public float maxRandomSpeed = 20f;

    GameObject panel;
    Transform UICanvasPos;

    public void ControlRandomSpeed()
    {
        if(minRandomSpeed < maxRandomSpeed - 1)
        {
            minRandomSpeed++;
        }
    }

    public void GameOver()
    {
        GameObject.Find("Pause Button").GetComponent<Button>().interactable = false;
        UICanvasPos = GameObject.Find("UI Canvas").GetComponent<Transform>();

        if (panel == null)
        {
            panel = Instantiate(Resources.Load<GameObject>("GameOver Panel"), UICanvasPos);
        }
        else
        {
            panel.SetActive(true);
        }

        state = false;
    }

    //로드박스에 부딪힐때마다 
    public void IncreaseSpeed()
    {
        if(speed < limitSpeed)
        {
            speed++;
        }
    }
    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        state = true;
        speed = 20;

        Time.timeScale = 1f;

    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
        Time.timeScale = 1f;
    }

}
