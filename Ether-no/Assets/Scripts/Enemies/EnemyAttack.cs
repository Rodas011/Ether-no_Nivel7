using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    //Stats
    public GameObject bullet;
    public Transform attackPoint;
    public float shootForce = 10f;
    public float attackRange = 10f;
    public int numberOfBullets = 5;
    public float bulletSpread = 10f;

    private float frecuency; //Time between shots
    private bool readyToShoot = true;
    private Transform player;
    private LayerMask whatIsPlayer;
    private bool playerInAttackRange;
    private EnemyController controller;

    void Awake()
    {
        //Get the player and the layer mask
        player = GameObject.FindWithTag("Player").transform;
        whatIsPlayer = LayerMask.GetMask("whatIsPlayer");

        //Get the frecuency from EnemyController
        controller = GetComponent<EnemyController>();
        frecuency = controller.frecuency;
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

        //Calculate the start rotation of the bullets
        float facingRotation = transform.eulerAngles.y;
        float startRotation = facingRotation + bulletSpread / 2f;

        //Calculate the angle increase between bullets
        float angleIncrease = bulletSpread / ((float) numberOfBullets);

        //Instantiate the bullets
        for (int i = 0; i < numberOfBullets; i++)
        {
            //Calculate the rotation of the bullet
            float rotation = startRotation - angleIncrease * i;
            GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.Euler(0f, rotation, 0f));

            //Set the damage of the bullet
            currentBullet.GetComponent<BulletController>().damage = controller.damage;

            //Add force to the bullet
            currentBullet.GetComponent<Rigidbody>().AddForce(currentBullet.transform.forward * shootForce, ForceMode.Impulse);
        }

        Invoke("ResetShoot", frecuency);
    }

    void ResetShoot()
    {
        readyToShoot = true;
    }
}
