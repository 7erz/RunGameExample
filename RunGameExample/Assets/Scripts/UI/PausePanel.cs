using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    public void Resume()
    {
        Time.timeScale = 1.0f;

        gameObject.SetActive(false);
        GameObject.Find("Pause Button").GetComponent<Button>().interactable = true;
    }


    public void Setting()
    {

    }

    public void ExitGame()
    {
        //Time.timeScale = 1;
        GameObject.Find("Exit").GetComponent<Button>().interactable = false;
        StartCoroutine(AsyncSceneLoader.instance.AsyncLoad(SceneID.TITLE));
    }
}
