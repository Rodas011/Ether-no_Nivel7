using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "Scriptables/GameState")]
public class GameState : ScriptableObject
{
    public bool isPaused = false;
    public bool isGameOver = false;
    public bool bossSpawned = false;

    public void Reset()
    {
        isPaused = false;
        isGameOver = false;
        bossSpawned = false;
    }
}
