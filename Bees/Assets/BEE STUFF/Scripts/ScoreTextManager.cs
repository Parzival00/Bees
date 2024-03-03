using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreTextManager : scoreUIManager
{
    TMP_Text scoreText;
    private void Awake()
    {
        scoreText = GetComponentInChildren<TMP_Text>();
    }


    public override void ChangeScore(float newScore)
    {
        scoreText.text = newScore.ToString();
    }

}
