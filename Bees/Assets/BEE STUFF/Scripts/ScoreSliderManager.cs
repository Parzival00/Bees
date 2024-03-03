using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSliderManager : scoreUIManager
{
    [SerializeField]
    private Slider scoreSlider;



    public override void ChangeScore(float newScore)
    {
        scoreSlider.value = newScore;
    }

}
