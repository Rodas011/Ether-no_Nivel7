using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Rendering;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private float chaseRange = 1000f;

    private float speed;
    private Transform player;
    private LayerMask whatIsPlayer;
    private bool playerInChaseRange;
    private NavMeshAgent agent;
    private EnemyController controller;

    private void Awake()
    {
        //Get the player and the layer mask
        player = GameObject.FindWithTag("Player").transform;
        whatIsPlayer = LayerMask.GetMask("whatIsPlayer");
        
        //Get the speed from EnemyController
        controller = GetComponent<EnemyController>();
        speed = controller.speed;

        //Set the speed of the NavMeshAgent
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    private void Update()
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
        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));
        agent.SetDestination(player.position);
    }
}
