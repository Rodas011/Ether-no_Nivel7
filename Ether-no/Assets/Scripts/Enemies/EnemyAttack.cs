using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private int numberOfBullets = 5;
    [SerializeField] private float bulletSpread = 10f;

    private float frecuency; //Time between shots
    private bool readyToShoot = true;
    private Transform player;
    private LayerMask whatIsPlayer;
    private bool playerInAttackRange;
    private EnemyController controller;

    private void Awake()
    {
        //Get the player and the layer mask
        player = GameObject.FindWithTag("Player").transform;
        whatIsPlayer = LayerMask.GetMask("whatIsPlayer");

        //Get the frecuency from EnemyController
        controller = GetComponent<EnemyController>();
        frecuency = controller.frecuency;
    }

    private void Update()
    {
        //Shoot when the player is in range
        playerInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsPlayer);

        if (playerInAttackRange && readyToShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        transform.LookAt(new Vector3(player.position.x, transform.position.y, player.position.z));

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

            //Set the damage and force of the bullet
            currentBullet.GetComponent<BulletController>().damage = controller.damage;
            currentBullet.GetComponent<Rigidbody>().AddForce(currentBullet.transform.forward * shootForce, ForceMode.Impulse);
        }

        Invoke("ResetShoot", frecuency);
    }

    private void ResetShoot()
    {
        readyToShoot = true;
    }
}
