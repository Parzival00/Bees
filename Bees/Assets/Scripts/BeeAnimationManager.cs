using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BeeAnimationManager : MonoBehaviour
{
    Animator animator;
    public NavMeshAgent agent;
    public bool isFlying = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
        animator.SetBool("isFlying", isFlying);
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponentInParent<NavMeshAgent>();
        animator.SetBool("isFlying", isFlying);
    }

    private void FixedUpdate()
    {
        if(agent == null && animator != null) 
            animator.SetFloat("Speed", 0);
        else if (animator!=null)
            animator.SetFloat("Speed", agent.velocity.magnitude / agent.speed);

    }
}
