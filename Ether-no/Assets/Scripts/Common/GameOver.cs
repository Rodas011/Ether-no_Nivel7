using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    private void Start()
    {
        GameEvents.current.onGameOver += onGameOver;
    }

    private void onGameOver()
    {
        Debug.Log("Game Over!");
        SceneManager.LoadScene("StartMenu");
    }
}
