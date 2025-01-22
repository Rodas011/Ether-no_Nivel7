using UnityEngine;

public class EnemyAttackMelee : MonoBehaviour
{
    private float damage; //Damage per attack
    private float frecuency; // Time between attacks
    private bool isAttacking = false; // Prevent simultaneous attacks
    private Transform player;
    private EnemyController controller;

    private void Awake()
    {
        // Get the damage and attack frequency from the EnemyController
        controller = GetComponent<EnemyController>();
        damage = controller.damage;
        frecuency = controller.frecuency;
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Start attacking if the collision is with the player
        if (collision.gameObject.CompareTag("Player"))
        {
            player = collision.transform;
            if (!isAttacking)
            {
                isAttacking = true;
                InvokeRepeating("Attack", 0f, frecuency);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // Stop attacking when the player is no longer colliding
        if (collision.gameObject.CompareTag("Player"))
        {
            player = null;
            isAttacking = false;
            CancelInvoke("Attack");
        }
    }

    private void Attack()
    {
        if (player != null)
        {
            // Access the player's HealthController or similar to apply damage
            var healthController = player.GetComponent<HealthController>();
            if (healthController != null)
            {
                healthController.TakeDamage(damage);
            }
            else
            {
                Debug.LogWarning("Player does not have a HealthController component.");
            }
        }
        else
        {
            isAttacking = false;
            CancelInvoke("Attack");
        }
    }
}
