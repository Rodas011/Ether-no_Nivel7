using UnityEngine;

public class BulletController : MonoBehaviour
{
    //Stats
    public float maxLifetime = 3;

    public float damage;
    private GameObject shooter;

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
        //Logic for giving damage
        if(collision.GetComponent<HealthController>() != null)
        {
            collision.GetComponent<HealthController>().TakeDamage(damage);
        }
        else
        {
            Debug.LogError("No HealthController found in " + collision.name);
        }

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
        if (collision.GetComponent<Collider>().CompareTag("Enemy") || collision.GetComponent<Collider>().CompareTag("Player"))
        {
            Explode(collision);
        }else
        {
            Destroy(gameObject);
        }
    }

}