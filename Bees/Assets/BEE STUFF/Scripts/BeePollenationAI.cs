using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeePollenationAI : MonoBehaviour
{
    public Transform[] WayPoints;
    //public Transform hive;
    private NavMeshAgent agent;
    private int randomWayPoint;
    private bool movingToWayPoint;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        //gets all the flowers in the scene and assigns them as waypoints
        GameObject[] WayPointsObj = GameObject.FindGameObjectsWithTag("Flower");
        WayPoints = new Transform[WayPointsObj.Length];
        
        for(int i = 0; i < WayPoints.Length; i++)
        {
            WayPoints[i] = WayPointsObj[i].transform;
        }

        randomWayPoint = Random.Range(0, WayPoints.Length); // Choose a random waypoint
        movingToWayPoint = true;
        agent.destination = WayPoints[randomWayPoint].position;
        print("moving to " + WayPoints[randomWayPoint].gameObject.name + " at " + agent.destination.ToString());
    }

    // Update is called once per frame
    void Update()
    {
        //StartCoroutine(MoveLoop());
        print("moving to " + WayPoints[randomWayPoint].gameObject.name + " at " + agent.destination.ToString());

        // When the bee reaches the current flower
        if (agent.remainingDistance < 0.1f && movingToWayPoint)
        {
            //move to hive once reached a flower
            movingToWayPoint = false;
            //agent.destination = hive.position; //change the waypoint to the hive
            print("moving to hive");
        }

        //When the bee reaches the hive
        if(agent.remainingDistance > 0.1f && !!movingToWayPoint)
        {
            randomWayPoint = Random.Range(0, WayPoints.Length); // Choose a random waypoint
            movingToWayPoint = true;
            agent.destination = WayPoints[randomWayPoint].position;
            print("moving to " + WayPoints[randomWayPoint].gameObject.name + " at " + WayPoints[randomWayPoint].position.ToString());
        }
        
        
        

        
    }
    //IEnumerator MoveLoop()
    //{
        //while (true) // Infinite loop
        //{
        //    randomWayPoint = Random.Range(0, WayPoints.Length); // Choose a random waypoint
        //    movingToWayPoint = true;
        //    agent.destination = WayPoints[randomWayPoint].position;

        //    // Wait until the bee reaches the destination
        //    while (agent.pathPending || agent.remainingDistance > 0.1f)
        //    {
        //        Debug.Log("Heading to Waypoint: " + randomWayPoint);
        //        yield return null;
        //    }

        //    movingToWayPoint = false;
        //    agent.destination = hive.position;

        //    // Wait until the bee reaches the hive
        //    while (agent.pathPending || agent.remainingDistance > 0.1f)
        //    {
        //        Debug.Log("Heading to Hive");
        //        yield return null;
        //    }
        //}
    //}
}
