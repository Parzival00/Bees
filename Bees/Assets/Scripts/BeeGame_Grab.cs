using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum GrabNames {Empty, Nectar, Pollen, Larvae, Honey,InsideHoney, Inside_Cap}
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

        else if (item_Name == GrabNames.Inside_Cap)
        {
            Debug.Log("NEXT SCENE");
            MiniGameManager.instance.NextMiniGame();
        }

        else if(item_Name == GrabNames.InsideHoney)
        {

            transform.localScale = transform.localScale *.9f;
            points -= 1;
            //check if minigame has honeyeatenMetric
            if (IncreasescoreIfAplicable(MetricName.HoneyEaten, 1))
            {
                audioManager.PlaySFX(audioManager.honeyEaten);
                Debug.Log("Honey Eaten");
            }
            if(points <= 1)
            {
                Destroy(gameObject);
            }
        }


        
    }

}
