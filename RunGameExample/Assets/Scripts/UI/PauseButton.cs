using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{
    GameObject panel;
    Transform UICanvasPos;

    private void Start()
    {
        UICanvasPos = GameObject.Find("UI Canvas").GetComponent<Transform>();
    }
    public void GamePause()
    {
        Time.timeScale = 0f;
        if (panel == null)
        {
            panel = Instantiate(Resources.Load<GameObject>("Pause Panel"), UICanvasPos);
        }
        panel.SetActive(true);
        gameObject.GetComponent<Button>().interactable = false;
    }
}