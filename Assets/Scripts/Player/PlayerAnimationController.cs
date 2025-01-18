using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    public GameState gameState;
    private Animator animator;
    private Rigidbody rigidBody;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Animate();
    }

    private void Animate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if(horizontal != 0f || vertical != 0f)
        {
            animator.SetFloat("Speed", 1f);
        }
        else
        {
            animator.SetFloat("Speed", 0f);
        }
    }

    private void AnimateWithVelocity()
    {
        animator.SetFloat("Speed", rigidBody.velocity.magnitude);
    }
}
