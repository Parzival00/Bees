using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeePollenationAI : MonoBehaviour
{
    public Transform[] WayPoints;
    public Transform hive;
    private NavMeshAgent agent;
    private int randomWayPoint;
    private bool movingToWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        StartCoroutine(MoveLoop());

    }
    IEnumerator MoveLoop()
    {
        while (true) // Infinite loop
        {
            randomWayPoint = Random.Range(0, WayPoints.Length); // Choose a random waypoint
            movingToWayPoint = true;
            agent.destination = WayPoints[randomWayPoint].position;

            // Wait until the bee reaches the destination
            while (agent.pathPending || agent.remainingDistance > 0.1f)
            {
                Debug.Log("Heading to Waypoint: " + randomWayPoint);
                yield return null;
            }

            movingToWayPoint = false;
            agent.destination = hive.position;

            // Wait until the bee reaches the hive
            while (agent.pathPending || agent.remainingDistance > 0.1f)
            {
                Debug.Log("Heading to Hive");
                yield return null;
            }
        }
    }
}
