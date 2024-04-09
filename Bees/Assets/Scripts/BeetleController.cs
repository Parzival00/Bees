using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeetleController : MonoBehaviour
{
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Transform escapeLocation;
    [SerializeField] float timeToLayEggs;
    [SerializeField] float distanceToKeepFromPlayer;

    int combsFailed = 0;
    int combsSaved = 0;
    float timer = 0f;

    GameObject player ;
    
    // Start is called before the first frame update
    void Start()
    {
        //get random cell and make that the target destination for the navmesh
        GetNewDestination();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, navAgent.destination) < 1f) //checks if the beetle is within a reasonable radius to the targeted comb
        {
            timer += Time.deltaTime;

            if(timer >= timeToLayEggs) // spawn the egg if the beetle has taken enough time to lay it
            {
                //spawn egg in honeycomb here
                combsFailed++;
                GetNewDestination();
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }

        if(Vector3.Distance(transform.position, player.transform.position) < distanceToKeepFromPlayer) //if within radius of the player, run away
        {
            navAgent.destination = escapeLocation.position;
        }

        if(Vector3.Distance(transform.position, escapeLocation.position) < distanceToKeepFromPlayer) //destroy if it gets to the escape location
        {
            Destroy(gameObject);
        }


    }

    /// <summary>
    /// Gets the location of a random open honey comb in the hive
    /// </summary>
    void GetNewDestination()
    {

    }
}
