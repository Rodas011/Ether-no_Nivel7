using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    public event Action OnGameOver;
    public event Action OnFinnish;
    public event Action OnPause;
    public event Action<GameObject> OnObjectDied;
    public event Action OnStageUp;

    private void Awake()
    {
        current = this;
    }

    public void GameOver()
    {
        OnGameOver?.Invoke();
    }

    public void Finnish()
    {
        OnFinnish?.Invoke();
    }

    public void Pause()
    {
        OnPause?.Invoke();
    }

    public void ObjectDied(GameObject obj)
    {
        OnObjectDied?.Invoke(obj);
    }

    public void StageUp()
    {
        OnStageUp?.Invoke();
    }
}