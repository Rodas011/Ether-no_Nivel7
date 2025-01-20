using UnityEngine;

public class GameEventManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private UIManager uiManager;
    [SerializeField] private ProgressionManager progressionManager;
    [SerializeField] private FaithManager faithManager;

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
        GameEvents.current.OnStageUp += HandleStageUp;
    }

    private void OnDestroy()
    {
        GameEvents.current.OnGameOver -= HandleGameOver;
        GameEvents.current.OnFinnish -= HandleFinnish;
        GameEvents.current.OnPause -= HandlePause;
        GameEvents.current.OnObjectDied -= HandleObjectDied;
        GameEvents.current.OnStageUp -= HandleStageUp;
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
            if (obj.TryGetComponent<EnemyController>(out var enemyController))
            {
                progressionManager.AddExperience(enemyController.experienceValue);
                faithManager.AddFaith(enemyController.faithValue);
            }
            Destroy(obj);
        }
    }

    private void HandleStageUp()
    {
        gameState.isPaused = true;
        Time.timeScale = 0f;
        uiManager.ShowTempUpgradesCanvas(true);
    }

}
