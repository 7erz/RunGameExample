using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class ScoreUi : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] int score;

    private void Start()
    {
        StartCoroutine(IncreaseScore());
    }

    IEnumerator IncreaseScore()
    {
        while (GameManager.instance.state)
        {
            yield return new WaitForSeconds(0.25f);

            if (!GameManager.instance.state)
            {
                DataManager.instance.RenewalScore(score);
                yield break;
            }

            score = score + 10;
            scoreText.text = score.ToString() + "m";
        }

    }

}
