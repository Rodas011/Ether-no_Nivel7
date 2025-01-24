using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEventManager : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private Upgrades upgrades;
    [SerializeField] private UIManagerCS uiManager;
    [SerializeField] private ProgressionManager progressionManager;
    [SerializeField] private FaithManager faithManager;

    private void Awake()
    {
        Time.timeScale = 1f;
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
        uiManager.ShowGameOver();
        Time.timeScale = 0f;
    }

    private void HandleFinnish()
    {
        gameState.isPaused = true;
        Time.timeScale = 0f;
        gameState.isGameOver = true;
        //uiManager.ShowFinishCanvas(true);
        Debug.Log("Finnish!");

        SceneManager.LoadScene(3);
    }

    private void HandlePause()
    {
        if (!gameState.isPaused)
        {
            gameState.isPaused = true;
            Time.timeScale = 0f;
            //uiManager.ShowPauseCanvas(true);
        }
        else
        {
            gameState.isPaused = false;
            Time.timeScale = 1f;
            //uiManager.ShowPauseCanvas(false);
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
        //uiManager.ShowTempUpgradesCanvas(true);
    }

}
