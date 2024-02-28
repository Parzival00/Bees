using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PollenManager : MonoBehaviour
{
    public Transform playerCamera;
    public Pollen playerPollen;

    private float detectDistance = 10;

    public GameObject[] Flowers;
    public GameObject currentFlower;
    public GameObject PollenMenu = null;
    public TMP_Text pollenCounterText;

    public bool nearFlower;

    void Start()
    {
        playerPollen.count = 0;
        Debug.Log("Current Pollen: " + getPollenCount());

        Flowers = GameObject.FindGameObjectsWithTag("Flower");
        if (Flowers.Length == 0)
        {
            Debug.LogWarning("No flowers found in the scene.");
        }
    }

    void Update()
    {
        getCurrentFlower();

        if (nearFlower && PollenMenu != null)
        {
            PollenMenu.transform.LookAt(playerCamera);
            pollenCounterText.SetText("Pollen: " + getPollenCount());
        }
    }

    public void getCurrentFlower()
    {
        foreach (GameObject f in Flowers)
        {
            float flowerDistance = Vector3.Distance(transform.position, f.transform.position);
            if (flowerDistance <= detectDistance)
            {
                currentFlower = f;
                PollenMenu = currentFlower.transform.GetChild(0).gameObject;

                if (PollenMenu != null)
                {
                    pollenCounterText = PollenMenu.transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
                    PollenMenu.SetActive(true);
                    nearFlower = true;
                }
                else
                {
                    Debug.LogWarning("PollenMenu or its child objects are null.");
                }

                return;  // Exit the loop once a flower is found
            }
        }

        // No flower found, set variables accordingly
        PollenMenu?.SetActive(false);
        nearFlower = false;
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

