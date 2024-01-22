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
    //이동하면서 페이드인 페이드 아웃 할 때 좋음
    [SerializeField] float time;
    [SerializeField] Image fadeImage;

    public IEnumerator FadeIn()
    {
        Debug.Log("실행");
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

        //bool allowSceneActivation : 장면이 준비되는 즉시 장면을 활성화시킬 것 인지 허용하는 기능
        asyncOperation.allowSceneActivation = false;

        Color color = fadeImage.color;
        color.a = 0;

        while(asyncOperation.isDone == false)
        {
            color.a += Time.deltaTime;

            fadeImage.color = color;

            if(asyncOperation.progress >= 0.9f)
            {
                //알파값 러프로 증가
                color.a = Mathf.Lerp(color.a, 1f, Time.deltaTime * time);
                fadeImage.color = color;

                //알파값이 1보다 크거나 같다면
                if (color.a >= 1f)
                {
                    //allowSceneActivation 실행
                    asyncOperation.allowSceneActivation = true;
                    yield break;
                }
                yield return null;
            }
        }
        //bool isDone : 해당 동작이 준비 되었는 지 판단하는 기능

        //float progress : 작업의 진행 정도를 0~1사이에 값으로 확인


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
