using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoadBox : CollisionObject
{
    [SerializeField] float initSpeed;
    [SerializeField] UnityEvent callback;
    [SerializeField] LevelManager levelManager;

    private void Start()
    {
        initSpeed = GameManager.instance.speed;
    }

    public override void Activate(Runner runner)
    {
        callback.Invoke();

        GameManager.instance.IncreaseSpeed();

        //더이상 사용하지 않음
        //DataManager.instance.data.score += 10;
        //DataManager.instance.Save();
        //levelManager.ControlLevel();

        runner.animator.speed = GameManager.instance.speed / initSpeed;
    }


}
