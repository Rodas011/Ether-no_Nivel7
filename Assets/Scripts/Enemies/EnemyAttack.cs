using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private float attackRange = 10f;
    [SerializeField] private int bulletsPerShot = 5;
    [SerializeField] private float bulletSpread = 10f;

    private float damage; //Damage per shot
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

        //Get the damage and frecuency from EnemyController
        controller = GetComponent<EnemyController>();
        damage = controller.damage;
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
        
        //Calculate the start rotation of the bullets
        float facingRotation = transform.eulerAngles.y;
        float startRotation = facingRotation + bulletSpread / 2f;

        //Calculate the angle increase between bullets
        float angleIncrease = bulletSpread / ((float) bulletsPerShot);

        //Instantiate the bullets
        for (int i = 0; i < bulletsPerShot; i++)
        {
            //Calculate the rotation of the bullet
            float rotation = startRotation - angleIncrease * i;
            GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.Euler(0f, rotation, 0f));

            //Set the damage and force of the bullet
            currentBullet.GetComponent<BulletController>().damage = damage;
            currentBullet.GetComponent<Rigidbody>().AddForce(currentBullet.transform.forward * shootForce, ForceMode.Impulse);
        }

        Invoke("ResetShoot", frecuency);
    }

    private void ResetShoot()
    {
        readyToShoot = true;
    }
}
