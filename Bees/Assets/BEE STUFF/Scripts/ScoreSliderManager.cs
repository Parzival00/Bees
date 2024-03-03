using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ScoreSliderManager : scoreUIManager
{
    Slider scoreSlider;
    private void Awake()
    {
        scoreSlider = GetComponent<Slider>();
    }


    public override void ChangeScore(float newScore)
    {
        scoreSlider.value = newScore;
    }

}
