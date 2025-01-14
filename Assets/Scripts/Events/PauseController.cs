using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseController : MonoBehaviour
{
    [SerializeField] private GameState gameState;

    private void Update()
    {
        PauseWithInput();
    }

    private void PauseWithInput()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !gameState.isGameOver)
        {
            GameEvents.current.Pause();
        }
    }

    public void PauseFromMenu()
    {
        GameEvents.current.Pause();
    }

}
