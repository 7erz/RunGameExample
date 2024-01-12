using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : Singleton<InputManager>     //��� �޾����Ƿ� �̱����� ��
{
    public Action keyAction;

    void Update()
    {
        //Input.anyKey : key�Է��� ���� ���� üũ
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
