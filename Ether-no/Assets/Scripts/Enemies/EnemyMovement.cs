using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    //Stats
    public float chaseRange = 1000f;

    private bool playerInChaseRange;
    private Transform player;
    private LayerMask whatIsPlayer;
    private NavMeshAgent agent;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        whatIsPlayer = LayerMask.GetMask("whatIsPlayer");
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        //Chase when the player is in range
        playerInChaseRange = Physics.CheckSphere(transform.position, chaseRange, whatIsPlayer);

        if (playerInChaseRange)
        {
            Chase();
        }
    }

    private void Chase()
    {
        transform.LookAt(player.position);
        agent.SetDestination(player.position);
    }


}
