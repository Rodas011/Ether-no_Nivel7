using UnityEngine;

public class UIManager : MonoBehaviour
{
    private GameObject gameOverCanvas;
    private GameObject finishCanvas;
    private GameObject pauseCanvas;
    private GameObject tempUpgradesCanvas;

    private void Awake()
    {
        // Find the canvas objects, set them to inactive, and controlls error if not found.
        if (GameObject.Find("CanvasGameOver"))
        {
            gameOverCanvas = GameObject.Find("CanvasGameOver");
            gameOverCanvas.SetActive(false);
        }

        if (GameObject.Find("CanvasFinish"))
        {
            finishCanvas = GameObject.Find("CanvasFinish");
            finishCanvas.SetActive(false);
        }


        if (GameObject.Find("CanvasPause"))
        {
            pauseCanvas = GameObject.Find("CanvasPause");
            pauseCanvas.SetActive(false);
        }

        if (GameObject.Find("CanvasTempUpgrades"))
        {
            tempUpgradesCanvas = GameObject.Find("CanvasTempUpgrades");
            tempUpgradesCanvas.SetActive(false);
        }
        
    }

    public void ShowGameOverCanvas(bool show)
    {
        if (gameOverCanvas) gameOverCanvas.SetActive(show);
    }

    public void ShowFinishCanvas(bool show)
    {
        if (finishCanvas) finishCanvas.SetActive(show);
    }

    public void ShowPauseCanvas(bool show)
    {
        if (pauseCanvas) pauseCanvas.SetActive(show);
    }

    public void ShowTempUpgradesCanvas(bool show)
    {
        if (tempUpgradesCanvas) tempUpgradesCanvas.SetActive(show);
    }
}