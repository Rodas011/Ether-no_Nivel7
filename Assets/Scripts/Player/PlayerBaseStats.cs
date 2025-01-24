using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptables/PlayerStats")]
public class PlayerBaseStats : ScriptableObject
{
    public float damage;
    public float defense;
    public float health;
    public float speed;
    public float attackFrequency;
    public float shieldFrequency;
    public int faith;

    public void OnEnable()
    {
        ResetStats();
        faith = 0;
    }

    public void ResetStats()
    {
        damage = 10f;
        defense = 1f;
        health = 100f;
        speed = 5f;
        attackFrequency = 0.5f;
        shieldFrequency = 4f;
    }

}
