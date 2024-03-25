using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum GrabNames {Empty, Nectar, Pollen, Larvae, Honey,InsideHoney}
public class BeeGame_Grab : ScoreModifier
{
    public GrabNames item_Name;
    public float points = 1;

    public bool being_Held;

    //Audio Manager
    AudioManager audioManager;

    //Audio
    private void Awake()
    {
       audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void ON_SelectEntered()
    {
        being_Held = true;
        //POLLEN MINI GAME
        if(item_Name == GrabNames.Pollen)
        {

            //check if minigame has pollen collected score metric
            if (IncreasescoreIfAplicable(MetricName.PollenCollected, points))
            {
                audioManager.PlaySFX(audioManager.itemCollected);
                //if so, yeet
                Destroy(gameObject);
            }
        }

        //BIRTH MINIGAME
        else if(item_Name == GrabNames.InsideHoney)
        {
            //check if minigame has honeyeatenMetric
            if (IncreasescoreIfAplicable(MetricName.HoneyEaten, points))
            {
                audioManager.PlaySFX(audioManager.honeyEaten);
                //if so, yeet
                Destroy(gameObject);
            }
        }
        
    }

}
