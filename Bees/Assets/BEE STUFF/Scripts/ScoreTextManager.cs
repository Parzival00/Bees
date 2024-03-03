using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class ScoreTextManager : scoreUIManager
{

    [SerializeField] private TMP_Text scoreText;



    public override void ChangeScore(float newScore)
    {
        scoreText.text = newScore.ToString();
    }

}
