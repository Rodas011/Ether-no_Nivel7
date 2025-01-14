using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Player Stats")]
    [SerializeField] private PlayerBaseStats baseStats;
    public float damage = 10f;
    public float defense = 1f;
    public float health = 100f;
    public float speed = 5f;
    public float frecuency = 0.5f;

    [Header("Player Components")]
    [SerializeField] private PlayerAttack playerAttack;
    [SerializeField] private PlayerMovement playerMovement;

    [Header("Player Dependencies")]
    [SerializeField] private GameState gameState;

    private void Awake()
    {
        //Get the base stats from the PlayerBaseStats scriptable object
        damage = baseStats.damage;
        defense = baseStats.defense;
        health = baseStats.health;
        speed = baseStats.speed;
        frecuency = baseStats.frecuency;
    }

    private void Start()
    {
        //Set the player components
        playerAttack = GetComponent<PlayerAttack>();
        playerMovement = GetComponent<PlayerMovement>();

        //Set the player dependencies
        playerAttack.SetDependencies(gameState);
        playerMovement.SetDependencies(gameState);
    }

}
