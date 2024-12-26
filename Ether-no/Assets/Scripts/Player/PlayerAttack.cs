using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject bullet;
    public Transform attackPoint;
    public float shootForce = 300f;
    public float frecuency = 0.5f; //Time between shots

    private bool readyToShoot = true;

    void Update()
    {
        if (Input.GetButton("Fire1") && readyToShoot)
        {
            Shoot();
        }
    }

    void Shoot()
    {
        readyToShoot = false;

        Vector3 direction = transform.forward;
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, Quaternion.identity);
        currentBullet.transform.forward = direction.normalized;

        currentBullet.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);

        Invoke("ResetShoot", frecuency);
    }

    void ResetShoot()
    {
        readyToShoot = true;
    }
}
