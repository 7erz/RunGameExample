using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineCache
{
    class FloatCompare : IEqualityComparer<float>
    {
        public bool Equals(float x, float y)
        {
            return x == y;
        }

        public int GetHashCode(float obj)
        {
            return obj.GetHashCode();
        }
    }

    //값이 바뀌면 재컴파일 해야하기에?
    private static readonly Dictionary<float,WaitForSeconds> timeInterval = new Dictionary<float,WaitForSeconds>(new FloatCompare());

    public static WaitForSeconds waitForSeconds(float time)
    {
        WaitForSeconds waitForSeconds;
        
        // ContainsKey 랑 TryGetValue 비교??
        if(timeInterval.TryGetValue(time, out waitForSeconds) == false)
        {
            timeInterval.Add(time, waitForSeconds = new WaitForSeconds(time));
        }

        return waitForSeconds;
    }


}
