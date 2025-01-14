using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private UIManager uiManager;

    private void Awake()
    {
        gameState.Reset();
    }

    private void Start()
    {
        GameEvents.current.OnGameOver += HandleGameOver;
        GameEvents.current.OnFinnish += HandleFinnish;
        GameEvents.current.OnPause += HandlePause;
        GameEvents.current.OnObjectDied += HandleObjectDied;
    }

    private void HandleGameOver()
    {
        gameState.isPaused = true;
        Time.timeScale = 0f;
        gameState.isGameOver = true;
        uiManager.ShowGameOverCanvas(true);
        Debug.Log("Game Over!");
    }

    private void HandleFinnish()
    {
        gameState.isPaused = true;
        Time.timeScale = 0f;
        gameState.isGameOver = true;
        uiManager.ShowFinishCanvas(true);
        Debug.Log("Finnish!");
    }

    private void HandlePause()
    {
        if (!gameState.isPaused)
        {
            gameState.isPaused = true;
            Time.timeScale = 0f;
            uiManager.ShowPauseCanvas(true);
        }
        else
        {
            gameState.isPaused = false;
            Time.timeScale = 1f;
            uiManager.ShowPauseCanvas(false);
        }
    }

    private void HandleObjectDied(GameObject obj)
    {
        if (obj.CompareTag("Player"))
        {
            HandleGameOver();
        }
        else if (obj.CompareTag("Boss"))
        {
            HandleFinnish();
            Destroy(obj);
        }
        else
        {
            Destroy(obj);
        }
    }
}
