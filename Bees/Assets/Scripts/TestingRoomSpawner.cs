using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingRoomSpawner : MonoBehaviour
{
    public GameObject larva, Nectar;
    public Transform spawnSpot;

    public void SpawnLarva()
    {
        Instantiate(larva, spawnSpot.position, Quaternion.identity);
    }

    public void SpawnNectar()
    {
        Instantiate(Nectar, spawnSpot.position, Quaternion.identity);
    }
}
