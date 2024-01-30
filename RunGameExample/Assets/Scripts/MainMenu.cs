using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] Animator animator;
    public void StartGame()
    {
        //AsyncSceneLoader.instance.AsynLoad((SceneID.GAME));
        animator.SetTrigger("Start");

        StartCoroutine(AsyncSceneLoader.instance.AsyncLoad(SceneID.GAME));
    }

}
