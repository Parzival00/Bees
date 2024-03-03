using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GrabNames {Empty, Nectar, Pollen, Larvae, Honey}
public class BeeGame_Grab : MonoBehaviour
{
    public GrabNames item_Name;
    public MiniGameScriptable[] miniGamesUsed;
    public bool being_Held;
    public bool deleteOnGrab;

    public void ON_SelectEntered()
    {
        being_Held = true;
        if (deleteOnGrab)
        {
            //add info before destroy (refrence UI to add point for pollen and MnigameManager)

            //MinigameManager info
            //Total collected
            //total pollenated
            //currently carry

            Destroy(gameObject);
        }
    }
    public void On_SelectExited()
    {
    }
}
