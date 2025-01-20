using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float shootForce = 10f;
    [SerializeField] private float angleBetweenBullets = 10f;

    private float damage; //Damage per shot
    private float frecuency; //Time between shots
    private int bulletsPerShot;
    private float bulletSpread;
    private bool readyToShoot = true;
    private PlayerController controller;
    private GameState gameState;

    public void SetDependencies(GameState gameState)
    {
        this.gameState = gameState;
    }

    private void Awake()
    {
        //Get the frecuency from PlayerController
        controller = GetComponent<PlayerController>();
    }

    private void Update()
    {
        //Shoot when the player clicks the left mouse button
        if (Input.GetButton("Fire1") && readyToShoot && !gameState.isPaused)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        readyToShoot = false;
        frecuency = controller.attackFrequency;
        damage = controller.damage;
        bulletsPerShot = controller.bulletsPerShot;
        bulletSpread = angleBetweenBullets * ((float)bulletsPerShot - 1);

        //Calculate the start rotation of the bullets
        float facingRotation = transform.eulerAngles.y;
        float startRotation = facingRotation + bulletSpread / 2f;

        //Calculate the angle increase between bullets
        float angleIncrease = angleBetweenBullets;

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
