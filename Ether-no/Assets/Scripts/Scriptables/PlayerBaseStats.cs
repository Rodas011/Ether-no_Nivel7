using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerStats", menuName = "Scriptables/PlayerStats")]
public class PlayerBaseStats : ScriptableObject
{
    public float damage = 10f;
    public float defense = 1f;
    public float health = 100f;
    public float speed = 5f;
    public float frecuency = 0.5f;
}
