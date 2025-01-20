using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTimer : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    public static SimpleTimer current;
    [HideInInspector] public float time = 0;

    private void Awake()
    {
        current = this;
    }

    void Update()
    {
        if(!gameState.isPaused && !gameState.isGameOver)
        {
            time += Time.deltaTime;
        }
    }
}
