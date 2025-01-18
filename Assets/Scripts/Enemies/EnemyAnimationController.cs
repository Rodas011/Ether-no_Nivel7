using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        animator.SetFloat("Speed", agent.velocity.magnitude);
    }
}
