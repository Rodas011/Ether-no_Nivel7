using UnityEngine;

public class DragonSpawner : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject boss;
    [SerializeField] private Transform bossSpawnPoint;
    [SerializeField] private float timeBossSpawn = 60f;

    void Update()
    {
        if (gameState.isGameOver || gameState.isPaused)
        {
            return;
        }

        if (SimpleTimer.current.time > timeBossSpawn && GameObject.FindWithTag("Boss") == null)
        {
            SpawnBoss();
        }
    }

    private void SpawnBoss()
    {
        GameObject currentBoss = Instantiate(boss, bossSpawnPoint.position, Quaternion.identity);
        currentBoss.name = "Boss";
        gameState.bossSpawned = true;
    }
}
