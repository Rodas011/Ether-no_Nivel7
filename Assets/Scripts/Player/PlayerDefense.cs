using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDefense : MonoBehaviour
{
    [SerializeField] private GameObject shield;

    private float shieldDuration;
    private float shieldFrecuency;
    private bool readyToDefense = true;
    private PlayerController controller;
    private GameState gameState;

    public void SetDependencies(GameState gameState)
    {
        this.gameState = gameState;
    }

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        shield.SetActive(false);
    }

    private void Update()
    {
        //Activate the shield when the player clicks the right mouse button
        if (Input.GetButton("Fire2") && readyToDefense && !gameState.isPaused)
        {
            Defense();
        }
    }

    private void Defense()
    {
        readyToDefense = false;
        shieldDuration = controller.shieldDuration;
        shieldFrecuency = controller.shieldFrecuency;

        shield.SetActive(true);
        controller.isShieldActive = true;
        StartCoroutine(DisableShield());

        Invoke("ResetDefense", shieldFrecuency);
    }

    private IEnumerator DisableShield()
    {
        yield return new WaitForSeconds(shieldDuration);
        shield.SetActive(false);
        controller.isShieldActive = false;
    }

    public void ResetDefense()
    {
        readyToDefense = true;
    }
}
