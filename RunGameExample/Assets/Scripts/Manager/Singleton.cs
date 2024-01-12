using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour //제약 조건
{
    public static T instance
    {
        get;
        private set;
    }

    protected virtual void Awake()
    {
        if(instance == null)
        {
            instance = (T)FindAnyObjectByType(typeof(T));
        }
        else
        {
            //하나만 존재해야 함
            Destroy(gameObject);
            //되돌아갔을 땐 DontDestroyOnLoad(instance.gameObject); 이 실행되지 않게 함
            return;
        }
        DontDestroyOnLoad(instance.gameObject);
        
    }
}
