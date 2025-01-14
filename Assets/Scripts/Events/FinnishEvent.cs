using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinnishEvent : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    private GameObject finnishCanvas;

    private void Awake()
    {
        if (GameObject.Find("CanvasFinish"))
        {
            finnishCanvas = GameObject.Find("CanvasFinish");
            finnishCanvas.SetActive(false);
        }
        else
        {
            Debug.LogError("Canvas for Game Over not found");
        }
    }

    private void Start()
    {
        GameEvents.current.onFinnish += onFinnish;
    }

    private void onFinnish()
    {
        gameState.isGameOver = true;
        finnishCanvas.SetActive(true);
        Debug.Log("Finnish!");
    }
}
