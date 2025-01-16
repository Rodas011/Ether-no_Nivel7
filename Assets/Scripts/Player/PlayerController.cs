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
    public float attackFrecuency;
    public float shieldFrecuency;

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
        attackFrecuency = baseStats.attackFrecuency;
        shieldFrecuency = baseStats.shieldFrecuency;
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

}
