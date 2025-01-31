using UnityEngine;

public class HealthController : MonoBehaviour
{
    [HideInInspector] public float maxHealth;
    [HideInInspector] public float currentHealth;
    private float defense;
    public bool isShieldActive;
    private PlayerController playerController;

    //Get the max health from the PlayerController or the EnemyController
    void Awake()
    {
        if (TryGetComponent<PlayerController>(out var playerController))
        {
            this.playerController = playerController;
            maxHealth = playerController.health;
            defense = playerController.defense;
        }
        else if (TryGetComponent<EnemyController>(out var enemyController))
        {
            maxHealth = enemyController.health;
            defense = enemyController.defense;
        }
        else
        {
            Debug.LogError("No PlayerController or EnemyController found! Defaulting maxHealth to 10.");
            maxHealth = 10;
        }
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        if(gameObject.CompareTag("Player") && playerController.isShieldActive)
        {
            Debug.Log("Shield is active, no damage taken.");
        }
        else
        {
            if(playerController != null)
            {
                defense = playerController.defense;
            }

            float realDamage = damage / defense;
            currentHealth -= realDamage;
            Debug.Log($"{gameObject.name} has taken {realDamage} damage.");

            if (currentHealth <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        GameEvents.current.ObjectDied(gameObject);
    }
}
