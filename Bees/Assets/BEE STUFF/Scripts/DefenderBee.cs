using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DefenderBee : MonoBehaviour
{
    [SerializeField] NavMeshAgent navAgent;
    GameObject wasp;

    // Start is called before the first frame update
    void Start()
    {
        wasp = GameObject.FindGameObjectWithTag("Wasp");
        navAgent.destination = wasp.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(wasp == null)
        {
            try
            {
                wasp = GameObject.FindGameObjectWithTag("Wasp");
                navAgent.destination = wasp.transform.position;
            }
            catch(Exception e)
            {
                navAgent.destination = transform.position;
            }
            
            
        }
    }
}
