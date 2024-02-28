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
        if(item_Name == GrabNames.Pollen)
        {
            IncreasescoreIfAplicable(MetricName.PollenCollected,points);
        }
        else if(item_Name == GrabNames.Honey)
        {
            DecreasescoreIfAplicable(MetricName.HoneyEaten,points);
        }
        
    }

}
