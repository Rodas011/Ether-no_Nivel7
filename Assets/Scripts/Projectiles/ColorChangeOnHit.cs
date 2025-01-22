using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeOnHit : MonoBehaviour
{
    private Renderer render;
    private Color originalColor;
    public Color hitColor = Color.red;
    public Color shieldColor = Color.blue;
    public float hitDuration = 0.1f;
    public float shieldDuration = 0.5f;

    private PlayerController playerController;
    private PlayerDefense playerDefense;
    private HealthController healthController;

    private bool wasReadyToDefense = false;

    private void Start()
    {
        if (TryGetComponent<PlayerController>(out var playerController))
        {
            this.playerController = playerController;
            playerDefense = gameObject.GetComponent<PlayerDefense>();
        }

        healthController = GetComponent<HealthController>();
        healthController.OnDamageTaken += HandleDamageTaken;

        render = GetComponentInChildren<Renderer>();
        originalColor = render.material.color;
    }

    private void OnDestroy()
    {
        healthController.OnDamageTaken -= HandleDamageTaken;
    }

    private void Update()
    {
        //HandleShieldChange();
    }

    private void HandleDamageTaken()
    {
        StartCoroutine(ChangeColor(hitColor));
    }

    private void HandleShieldChange()
    {
        if (playerController != null)
        {
            if (playerDefense.readyToDefense && !wasReadyToDefense)
            {
                StartCoroutine(ChangeColor(shieldColor));
            }
            wasReadyToDefense = playerDefense.readyToDefense;
        }
    }

    private IEnumerator ChangeColor(Color color)
    {
        render.material.color = color;
        yield return new WaitForSeconds(hitDuration);
        render.material.color = originalColor;
    }
}
