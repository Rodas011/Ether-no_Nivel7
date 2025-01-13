using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    public static GameEvents current;

    private void Awake()
    {
        current = this;
        gameState.Reset();
    }

    public event Action onGameOver;

    public void GameOver()
    {
        if (onGameOver != null)
        {
            onGameOver();
        }
    }
}
