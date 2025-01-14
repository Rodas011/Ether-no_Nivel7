using UnityEngine;

public class BulletController : MonoBehaviour
{
    public GameState gameState;

    //Stats
    public float maxLifetime = 3;

    [HideInInspector] public float damage;
    [HideInInspector] public Vector3 tempVelocity;

    void Update()
    {
        if(!gameState.isPaused)
        {
            maxLifetime -= Time.deltaTime;
            if (maxLifetime <= 0)
            {
                Destroy();
            }
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
        //Explode if bullet hits a valid target directly
        string[] validTags = { "Player", "Enemy", "Boss" };
        if (System.Array.Exists(validTags, tag => collision.CompareTag(tag)))
        {
            Explode(collision);
        }else
        {
            Destroy(gameObject);
        }
    }

}
