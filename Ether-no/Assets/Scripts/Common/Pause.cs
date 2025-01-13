using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    private GameObject pauseCanvas;

    private void Awake()
    {
        if (GameObject.Find("CanvasPause"))
        {
            pauseCanvas = GameObject.Find("CanvasPause");
            pauseCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("Canvas for Pause not found");
        }
    }

    private void Start()
    {
        GameEvents.current.onGameOver += onGameOver;
        GameEvents.current.onFinnish += onFinnish;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameState.isGameOver)
        {
            if(!gameState.isPaused)
            {
                PauseGame();
                pauseCanvas.SetActive(true);
            }
            else
            {
                UnpauseGame();
                pauseCanvas.SetActive(false);
            }
        }
    }

    private void onGameOver()
    {
        if (!gameState.isPaused)
        {
            PauseGame();
        }
    }

    private void onFinnish()
    {
        if (!gameState.isPaused)
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        gameState.isPaused = true;
        Time.timeScale = 0f;
    }

    public void UnpauseGame()
    {
        gameState.isPaused = false;
        Time.timeScale = 1f;
    }
}
