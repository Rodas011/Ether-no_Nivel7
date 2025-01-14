using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverEvent : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    private GameObject gameOverCanvas;

    private void Awake()
    {
        if (GameObject.Find("CanvasGameOver"))
        {
            gameOverCanvas = GameObject.Find("CanvasGameOver");
            gameOverCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("Canvas for Game Over not found");
        }
    }

    private void Start()
    {
        GameEvents.current.onGameOver += onGameOver;
    }

    private void onGameOver()
    {
        gameState.isGameOver = true;
        gameOverCanvas.SetActive(true);
        Debug.Log("Game Over!");
    }
}
