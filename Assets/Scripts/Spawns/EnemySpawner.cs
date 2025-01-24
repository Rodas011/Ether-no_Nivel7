using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float minRandomRange = 0.5f;
    [SerializeField] private float maxRandomRange = 1f;
    [SerializeField] private float maxDistanceForValidation = 3f;
    [SerializeField] private float spawnFrequencyInitial = 10f;
    [SerializeField] private float spawnFrequencyWithBoss = 10f;
    [SerializeField] private float spawnInitialWait = 2f;

    private Transform player;
    private int enemyNumber = 0;
    private float spawnFrequency = 0f; // Frecuency of enemy spawn
    private float spawnWait = 0f;    // Internal counter for spawn frequency
    private bool isReady = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Invoke("SetReady", spawnInitialWait);
    }

    private void Update()
    {
        if(!isReady || gameState.isGameOver || gameState.isPaused)
        {
            return;
        }

        if(spawnWait >= spawnFrequency)
        {
            SpawnEnemies();
            spawnWait = 0f;
            if(!gameState.bossSpawned)
            {
                // Increment spawn frecuency and asure that the spawn frequency is never lower than 1
                spawnFrequency = Mathf.Max(1f, spawnFrequencyInitial - (SimpleTimer.current.time) * 0.05f); 
            }
            else
            {
                spawnFrequency = spawnFrequencyWithBoss;
            }
        }
        spawnWait += Time.deltaTime;
    }

    private void SpawnEnemies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            float randomX = Random.Range(minRandomRange, maxRandomRange);
            float randomZ = Random.Range(minRandomRange, maxRandomRange);
            Vector3 offset = new Vector3(randomX, spawnPoint.position.y, randomZ);
            Vector3 spawnPosition = spawnPoint.position + offset;

            MakeAValidPoint(ref spawnPosition, maxDistanceForValidation);
            GameObject currentEnemy = Instantiate(enemy, spawnPosition, Quaternion.identity);
            enemyNumber++;
            currentEnemy.name = "Enemy" + enemyNumber;
        }
    }

    private void MakeAValidPoint(ref Vector3 point, float maxDistance)
    {
        Vector3 originalPoint = point;
        UnityEngine.AI.NavMeshHit hit;
        if (UnityEngine.AI.NavMesh.SamplePosition(point, out hit, maxDistance, UnityEngine.AI.NavMesh.AllAreas))
        {
            point = hit.position;
            return;
        }
        point = new Vector3(20, 0, 0);
        if (player.position.x > 0)
        {
            point = new Vector3(-20, 0, 0);
        }
        Debug.Log($"Invalid spawn point at {originalPoint}, enemy spawned at default points");
    }

    private void SetReady()
    {
        isReady = true;
    }
}
