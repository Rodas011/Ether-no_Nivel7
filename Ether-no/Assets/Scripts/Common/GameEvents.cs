using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
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
