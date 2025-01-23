using UnityEngine;
using System;

public class HealthController : MonoBehaviour
{
    [HideInInspector] public float maxHealth;
    [HideInInspector] public float currentHealth;
    public event Action OnDamageTaken;
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

    public void Heal(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        Debug.Log($"Player healed by {amount}. Current health: {currentHealth}");
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
            OnDamageTaken?.Invoke();

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
