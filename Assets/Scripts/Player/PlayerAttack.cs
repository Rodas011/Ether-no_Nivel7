using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform attackPoint;
    [SerializeField] private float shootForce = 10f;

    private float damage; //Damage per shot
    private float frecuency; //Time between shots
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
        frecuency = controller.frecuency;
        damage = controller.damage;
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

        //Instantiate the bullet
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, transform.rotation);

        //Set the damage and force of the bullet
        currentBullet.GetComponent<BulletController>().damage = damage;
        currentBullet.GetComponent<Rigidbody>().AddForce(transform.forward * shootForce, ForceMode.Impulse);

        Invoke("ResetShoot", frecuency);
    }

    private void ResetShoot()
    {
        readyToShoot = true;
    }
}
