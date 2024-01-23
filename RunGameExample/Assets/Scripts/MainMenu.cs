using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    
    public void StartGame()
    {
        //AsyncSceneLoader.instance.AsynLoad((SceneID.GAME));
        StartCoroutine(AsyncSceneLoader.instance.AsynLoad(SceneID.GAME));
    }
}
