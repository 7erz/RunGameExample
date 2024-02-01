using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameOverPanel : MonoBehaviour
{
    [SerializeField]TMP_Text bestScoreText;

    private void OnEnable()
    {
        StartCoroutine(ViewScore());
    }

    public void Resume()
    {
        Time.timeScale = 1;
        GameManager.instance.minRandomSpeed = 5f;
        StartCoroutine(AsyncSceneLoader.instance.AsyncLoad(SceneID.GAME));
        //한번만 버튼 누르게 수정하기
        GameObject.Find("Restart").GetComponent<Button>().interactable = false;
    }

    IEnumerator ViewScore()
    {
        yield return new WaitForSeconds(0.5f);

        DataManager.instance.Load();

        bestScoreText.text = DataManager.instance.data.bestScore.ToString() + "m";
    }
    
}
