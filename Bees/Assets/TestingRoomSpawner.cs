using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingRoomSpawner : MonoBehaviour
{
    public GameObject larva, Nectar;
    public Transform spawnSpot;

    public void SpawnLarva()
    {
        MiniGameManager.instance.SpawnMiniGameActors(larva, spawnSpot);
    }

    public void SpawnNectar()
    {
        MiniGameManager.instance.SpawnMiniGameActors(Nectar, spawnSpot);
    }
}
