using UnityEngine;

public class HealthItemController : MonoBehaviour
{
    [SerializeField] private float healAmount = 20f;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.TryGetComponent<HealthController>(out var healthController))
            {
                healthController.Heal(healAmount);
                Destroy(gameObject);
            }
        }
    }
}