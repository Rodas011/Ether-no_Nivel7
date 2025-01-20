using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Base Stats")]
    [SerializeField] private PlayerBaseStats baseStats;
    public float damage;
    public float defense;
    public float health;
    public float speed;
    public float attackFrequency;
    public float shieldFrequency;

    [Header("Player Special Abilities")]
    public int bulletsPerShot = 1;
    public float shieldDuration = 1f;
    public bool isShieldActive;

    [Header("Player Components")]
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private PlayerDefense playerDefense;

    [Header("Player Dependencies")]
    [SerializeField] private GameState gameState;

    private void Awake()
    {
        //Get the base stats from the PlayerBaseStats scriptable object
        damage = baseStats.damage;
        defense = baseStats.defense;
        health = baseStats.health;
        speed = baseStats.speed;
        attackFrequency = baseStats.attackFrequency;
        shieldFrequency = baseStats.shieldFrequency;
    }

    private void Start()
    {
        //Set the player components
        playerAttack = GetComponent<PlayerAttack>();
        playerMovement = GetComponent<PlayerMovement>();
        playerDefense = GetComponent<PlayerDefense>();

        //Set the player dependencies
        playerAttack.SetDependencies(gameState);
        playerMovement.SetDependencies(gameState);
        playerDefense.SetDependencies(gameState);
    }

    public void ModifyAtribute(string attribute, float value)
    {
        switch (attribute)
        {
            case "damage":
                damage += value;
                Debug.Log($"Damage increased by {value}. New damage: {damage}");
                break;

            case "defense":
                defense += value;
                Debug.Log($"Defense increased by {value}. New defense: {defense}");
                break;

            case "bulletsPerShot":
                bulletsPerShot += Mathf.RoundToInt(value);
                Debug.Log($"Bullets per shot increased by {value}. New bullets per shot: {bulletsPerShot}");
                break;

            case "shieldDuration":
                shieldDuration += value;
                Debug.Log($"Shield duration increased by {value}. New shield duration: {shieldDuration}s");
                break;

            default:
                Debug.LogWarning($"Unknown attribute: {attribute}");
                break;
        }
    }
}
