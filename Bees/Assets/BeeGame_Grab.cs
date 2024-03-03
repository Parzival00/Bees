using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GrabNames {Empty, Nectar, Pollen, Larvae, Honey,InsideHoney}
public class BeeGame_Grab : ScoreModifier
{
    public GrabNames item_Name;
    public MiniGameScriptable[] miniGamesUsed;
    public float points = 1;
    public bool being_Held;


    public void ON_SelectEntered()
    {
        being_Held = true;
        //POLLEN MINI GAME
        if(item_Name == GrabNames.Pollen)
        {

            //check if minigame has pollen collected score metric
            if (IncreasescoreIfAplicable(MetricName.PollenCollected, points))
            {
                //if so, yeet
                Destroy(gameObject);
            }
        }

        //BIRTH MINIGAME
        else if(item_Name == GrabNames.InsideHoney)
        {
            //check if minigame has honeyeatenMetric
            if (DecreasescoreIfAplicable(MetricName.HoneyEaten, points))
            {
                //if so, yeet
                Destroy(gameObject);
            }
        }
        
    }

}
