using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QueenBeeManager : MonoBehaviour
{
    public GameObject larvae;
    public Transform LarvaeSpawnSpot;

    private GameObject larvaeSpawn;

    private void Update()
    {
        if(larvaeSpawn == null)
        {
            larvaeSpawn = Instantiate(larvae,LarvaeSpawnSpot.position,Quaternion.identity);
        }
    }
}
