using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeCoroutine : Singleton<TimeCoroutine>
{
    IEnumerator WaitSecond(float seconds)
    {
        yield return new WaitForSeconds(seconds);
    }
}
