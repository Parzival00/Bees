using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkerBeeSpawner : MonoBehaviour
{
    public GameObject WorkerBeeGO;
    public float spawnInterval = 5;
    private float counter;

    private void Update()
    {
        counter += Time.deltaTime;
        if(counter > spawnInterval)
        {
            counter = 0;
            Instantiate(WorkerBeeGO, transform.position,Quaternion.identity);
        }
    }

}
