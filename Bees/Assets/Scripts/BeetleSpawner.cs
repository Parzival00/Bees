using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleSpawner : MonoBehaviour
{
    [SerializeField] GameObject beetlePrefab;
    [SerializeField] int numBeetlesAtOnce;
    [SerializeField] float timeBetweenChecks;

    BeetleController[] beetlesInGame;

    float checkTime = 0;


    void Update()
    {
        checkTime += Time.deltaTime;

        
        if(checkTime >= timeBetweenChecks) //doing the check at a time interval instead of every frame to preserve some performance
        {
            //counts the number of beetles in the scene to see if there needs to be more spawned
            beetlesInGame = GameObject.FindObjectsByType<BeetleController>(FindObjectsSortMode.None);

            for(int i = 0; i < numBeetlesAtOnce - beetlesInGame.Length; i++)
            {
                Instantiate(beetlePrefab);
            }
        }
    }
}
