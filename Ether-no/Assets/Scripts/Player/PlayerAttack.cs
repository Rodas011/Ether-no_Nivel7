using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    //Stats
    public GameObject bullet;
    public Transform attackPoint;
    public float shootForce = 300f;
    public float frecuency = 0.5f; //Time between shots

    private bool readyToShoot = true;

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

        //Add force to the bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);

        Invoke("ResetShoot", frecuency);
    }

    void ResetShoot()
    {
        readyToShoot = true;
    }
}
