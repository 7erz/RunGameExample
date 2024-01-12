using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>     //상속 받았으므로 싱글톤이 됨
{
    public Action keyAction;

    void Update()
    {
        //Input.anyKey : key입력이 들어는 상태 체크
        if (!Input.anyKey)
        {
            return;
        }
        if (keyAction != null)
        {
            keyAction.Invoke();
        }
    }
}
