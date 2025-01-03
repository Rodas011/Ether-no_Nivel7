using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //Stats
    public GameObject bullet;
    public Transform attackPoint;
    public float shootForce = 10f;
    public float frecuency = 0.5f; //Time between shots
    public float attackRange = 10f;

    private bool playerInAttackRange;
    private bool readyToShoot = true;
    private Transform player;
    private LayerMask whatIsPlayer;

    private void Awake()
    {
        player = GameObject.FindWithTag("Player").transform;
        whatIsPlayer = LayerMask.GetMask("whatIsPlayer");
    }

    void Update()
    {
        //Shoot when the player is in range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);
        
        if (playerInAttackRange && readyToShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        readyToShoot = false;

        transform.LookAt(player);

        //Instantiate the bullet
        Vector3 direction = transform.forward;
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = direction.normalized;

        //Add force to the bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);

        Invoke("ResetShoot", frecuency);
    }

    void ResetShoot()
    {
        readyToShoot = true;
    }
}
