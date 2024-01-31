using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Button startButton;
    public void StartGame()
    {
        //AsyncSceneLoader.instance.AsynLoad((SceneID.GAME));
        animator.SetTrigger("Start");
        startButton.interactable = false;
        //StartCoroutine(WaitSecond(0.5f));

        StartCoroutine(AsyncSceneLoader.instance.AsyncLoad(SceneID.GAME));
    }

    IEnumerator WaitSecond(float time)
    {
        yield return new WaitForSeconds(time);
    }

}
