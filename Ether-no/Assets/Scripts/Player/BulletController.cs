using UnityEngine;

public class BulletController : MonoBehaviour
{
    //Stats
    public float maxLifetime = 3;
    public float damage = 1;

    void Update()
    {
        //Destroy the bullet after some time
        maxLifetime -= Time.deltaTime;
        if (maxLifetime <= 0)
        {
            Destroy();
        }
    }

    private void Explode(Collider collision)
    {
        //Logic for giving damage to the enemy
        //collision.GetComponent<HealthController>().TakeDamage(damage);

        //Add a little delay
        Invoke("Destroy", 0.05f);

    }

    private void Destroy()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider collision)
    {
        //Explode if bullet hits an enemy directly
        if (collision.GetComponent<Collider>().CompareTag("Enemy"))
        {
            Explode(collision);
        }else
        {
            Destroy(gameObject);
        }
    }

}
