using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GrabNames {Empty, Nectar, Pollen, Larvae, Honey}
public class BeeGame_Grab : MonoBehaviour
{
    public GrabNames item_Name;
    public MiniGameScriptable[] miniGamesUsed;
    public bool being_Held;

    public void ON_SelectEntered()
    {
        being_Held = true;
    }
    public void On_SelectExited()
    {
    }
}
