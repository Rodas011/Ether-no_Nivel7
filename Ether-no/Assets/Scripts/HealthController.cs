using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    private float maxHealth;
    private float currentHealth;
    private float defense;

    //Get the max health from the PlayerController or the EnemyController

    void Start()
    {
        if (TryGetComponent<PlayerController>(out var playerController))
        {
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
        float realDamage = damage / defense;
        currentHealth -= realDamage;

        //Print damage given to the object
        Debug.Log($"{gameObject.name} has taken {realDamage} damage.");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log($"{gameObject.name} has died.");
        Destroy(gameObject); // Destruir el objeto como ejemplo de muerte
    }
}
