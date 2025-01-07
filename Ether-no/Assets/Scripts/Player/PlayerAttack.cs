using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Stats
    public GameObject bullet;
    public Transform attackPoint;
    public float shootForce = 10f;

    private float damage; //Damage per shot
    private float frecuency; //Time between shots
    private bool readyToShoot = true;
    private PlayerController controller;

    void Awake()
    {
        //Get the frecuency from PlayerController
        controller = GetComponent<PlayerController>();
        frecuency = controller.frecuency;
        damage = controller.damage;
    }

    void Update()
    {
        //Shoot when the player clicks the left mouse button
        if (Input.GetButton("Fire1") && readyToShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        readyToShoot = false;

        //Instantiate the bullet
        Vector3 direction = transform.forward;
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = direction.normalized;

        // Initialize the bullet with the shooter (this object)
        currentBullet.GetComponent<BulletController>().damage = damage;

        //Add force to the bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);

        Invoke("ResetShoot", frecuency);
    }

    void ResetShoot()
    {
        readyToShoot = true;
    }
}
