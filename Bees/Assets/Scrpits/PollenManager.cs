using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PollenManager : MonoBehaviour
{
    //The Player's Pollen
    public Pollen playerPollen;
    public TMP_Text pollenCounterText;

    // Start is called before the first frame update
    void Start()
    {
        //player's pollen starts at zero
        playerPollen.count = 0;
        Debug.Log("Current Pollen: " + getPollenCount());
    }

    // Update is called once per frame
    void Update()
    {
        pollenCounterText.SetText("Pollen: " + getPollenCount());
    }

    public void givePollen()
    {
        if (playerPollen.count > 0)
        {
            playerPollen.count--;
        }
    }

    public void takePollen()
    {
        playerPollen.count++;
    }

    public int getPollenCount()
    {
        return playerPollen.count;
    }
}
