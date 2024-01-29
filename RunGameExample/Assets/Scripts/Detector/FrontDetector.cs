using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrontDetector : CollisionObject
{
    [SerializeField] AudioClip crashed;
    public override void Activate(Runner runner)
    {
        Debug.Log("ºÎµúÇûÀ½");
        AudioManager.instance.SFXSound(crashed);
        runner.animator.Play("Die");
        GameManager.instance.GameOver();
    }
}
