using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUi : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] int score;

    IEnumerator IncreaseScore()
    {
        
        yield return new WaitForSeconds(0.25f);
    }

}
