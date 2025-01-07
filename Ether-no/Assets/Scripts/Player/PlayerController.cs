using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerBaseStats baseStats;

    public float damage = 10f;
    public float defense = 1f;
    public float health = 100f;
    public float speed = 5f;
    public float frecuency = 0.5f;

    private void Awake()
    {
        //Get the base stats from the PlayerBaseStats scriptable object
        damage = baseStats.damage;
        defense = baseStats.defense;
        health = baseStats.health;
        speed = baseStats.speed;
        frecuency = baseStats.frecuency;
    }

}
