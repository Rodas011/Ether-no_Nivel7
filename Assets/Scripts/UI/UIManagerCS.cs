using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManagerCS : MonoBehaviour
{
    public GameObject gameOverCanvas;

    private bool isGameOver = false;

    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    void Update()
    {
        if (!isGameOver && CheckIfGameOver())
        {
            
            ShowGameOver();
        }
    }

    private bool CheckIfGameOver()
    {
        return false;
    }

    public void ShowGameOver()
    {
        isGameOver = true;
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
    }


    public void Retry()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void BackToMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }
}
