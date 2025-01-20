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

    private bool wasReadyToDefense = false;

    private void Start()
    {
        if (TryGetComponent<PlayerController>(out var playerController))
        {
            this.playerController = playerController;
            playerDefense = gameObject.GetComponent<PlayerDefense>();
        }
        render = GetComponentInChildren<Renderer>();
        originalColor = render.material.color;
    }

    private void Update()
    {
        //HandleShieldChange();S
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (gameObject.CompareTag("Player") && playerController.isShieldActive)
        {
            return;
        }
        else
        {
            string[] validTags = { "Bullet" };
            if (System.Array.Exists(validTags, tag => collision.CompareTag(tag)))
            {
                StartCoroutine(ChangeColor(hitColor));
            }
        }
    }

    /*
    private void OnCollisionEnter(Collision collision)
    {
        string[] validTags = { "Player", "Enemy", "Boss" };
        if (System.Array.Exists(validTags, tag => collision.gameObject.CompareTag(tag)))
        {
            StartCoroutine(ChangeColor());
        }
    }*/

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
