using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using TMPro;

public class BeetleController : MonoBehaviour
{
    [SerializeField] NavMeshAgent navAgent;
    [SerializeField] Vector3 escapeLocation;
    [SerializeField] float timeToLayEggs;
    [SerializeField] float distanceToKeepFromPlayer;

    int combsFailed = 0;
    int combsSaved = 0;
    float timer = 0f;

    GameObject player ;

    Vector3 goal;

    //NEW ATTRIBUTES
    public MiniGameScriptable pestScriptable; //refrences the pest control scriptable -- JESSE
    public bool isDead; //check if beetle is dead --JESSE

    // Start is called before the first frame update
    void Start()
    {
        //get random cell and make that the target destination for the navmesh
        GetNewDestination();
        player = GameObject.FindGameObjectWithTag("Player").transform.GetChild(3).gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //print(Vector3.Distance(transform.position, escapeLocation));

        if (Vector3.Distance(transform.position, player.transform.position) <= distanceToKeepFromPlayer) //if within radius of the player, run away
        {
            //print("running away");
            navAgent.destination = escapeLocation;
        }
        else if (Vector3.Distance(transform.position, player.transform.position) >= distanceToKeepFromPlayer * 1.5f)
        {
            //print("not running away");
            navAgent.destination = goal;
        }
            

        if (Vector3.Distance(transform.position, escapeLocation) < 5) //destroy if it gets to the escape location
        {
            //print("escaping");
            combsSaved++;
            Destroy(gameObject);
        }

        if (Vector3.Distance(transform.position, navAgent.destination) < 1f) //checks if the beetle is within a reasonable radius to the targeted comb
        {
            timer += Time.deltaTime;

            if(timer >= timeToLayEggs) // spawn the egg if the beetle has taken enough time to lay it
            {
                //TODO - spawn egg in honeycomb here
                combsFailed++;
                GetNewDestination();
                timer = 0;
            }
        }
        else
        {
            timer = 0;
        }

        updateEnemiesDefeatedMetric(); //Call to method below - JESSE
    }

    //If beetle is dead, score of "enemies defeated" is increased by 1 -- JESSE
    public void updateEnemiesDefeatedMetric()
    {
        if (isDead)
        {
            pestScriptable.IncreaseScore(MetricName.EnemiesDefeated, 1f);
        }
    }

    /// <summary>
    /// Gets the location of a random open honey comb in the hive
    /// </summary>
    void GetNewDestination()
    {
        HiveCell[] cells = FindObjectsByType<HiveCell>(FindObjectsSortMode.None);
        int index = 0;
        Vector3 pos = Vector3.zero;
        //gets the location of the first cell that is uncapped 
        //do
        //{
            index = Random.Range(0, cells.Length);
            pos = cells[index].gameObject.transform.position;
        //}
        //while (cells[index].currCellState != CellState.Capped);
        goal = pos;
        navAgent.destination = pos;
    }
}
