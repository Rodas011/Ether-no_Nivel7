using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;
    public event Action OnGameOver;
    public event Action OnFinnish;
    public event Action OnPause;
    public event Action<GameObject> OnObjectDied;

    private void Awake()
    {
        current = this;
    }

    public void GameOver()
    {
        if (OnGameOver != null)
        {
            OnGameOver();
        }
    }

    public void Finnish()
    {
        if (OnFinnish != null)
        {
            OnFinnish();
        }
    }

    public void Pause()
    {
        if (OnPause != null)
        {
            OnPause();
        }
    }

    public void ObjectDied(GameObject obj)
    {
        if (OnObjectDied != null)
        {
            OnObjectDied(obj);
        }
    }
}
