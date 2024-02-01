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
        //�ѹ��� ��ư ������ �����ϱ�
        GameObject.Find("Restart").GetComponent<Button>().interactable = false;
    }

    IEnumerator ViewScore()
    {
        yield return new WaitForSeconds(0.5f);

        DataManager.instance.Load();

        bestScoreText.text = DataManager.instance.data.bestScore.ToString() + "m";
    }
    
}
