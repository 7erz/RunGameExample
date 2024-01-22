using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public enum SceneID
{
    TITLE,
    GAME
}

public class AsyncSceneLoader : Singleton<AsyncSceneLoader>
{
    //�̵��ϸ鼭 ���̵��� ���̵� �ƿ� �� �� ����
    [SerializeField] float time;
    [SerializeField] Image fadeImage;

    public IEnumerator FadeIn()
    {
        Debug.Log("����");
        Color color = fadeImage.color;

        color.a = 1f;

        fadeImage.gameObject.SetActive(true);

        while (color.a > 0)
        {
            
            color.a -= Time.deltaTime * time;
            fadeImage.color = color;

           yield return null;
        }
        fadeImage.gameObject.SetActive(false);
    }

    public IEnumerator AsynLoad(SceneID sceneID)
    {
        fadeImage.gameObject.SetActive(true);

        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync((int)sceneID);

        //bool allowSceneActivation : ����� �غ�Ǵ� ��� ����� Ȱ��ȭ��ų �� ���� ����ϴ� ���
        asyncOperation.allowSceneActivation = false;

        Color color = fadeImage.color;
        color.a = 0;

        while(asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;

            fadeImage.color = color;

            if(asyncOperation.progress >= 0.9f)
            {
                //���İ� ������ ����
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime * time);
                fadeImage.color = color;

                //���İ��� 1���� ũ�ų� ���ٸ�
                if (color.a >= 1f)
                {
                    //allowSceneActivation ����
                    asyncOperation.allowSceneActivation = true;
                    yield break;
                }
                yield return null;
            }
        }
        //bool isDone : �ش� ������ �غ� �Ǿ��� �� �Ǵ��ϴ� ���

        //float progress : �۾��� ���� ������ 0~1���̿� ������ Ȯ��


    }



    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        StartCoroutine (FadeIn());
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
