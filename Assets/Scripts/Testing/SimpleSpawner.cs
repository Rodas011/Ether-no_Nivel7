using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleSpawner : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject enemy;
    [SerializeField] private GameObject boss;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Transform bossSpawnPoint;
    [SerializeField] private float timeBossSpawn = 60f;
    [SerializeField] private float minRandomRange = 0.5f;
    [SerializeField] private float maxRandomRange = 1f;
    [SerializeField] private float maxDistanceForValidation = 3f;
    [SerializeField] private float spawnFrequencyWithBoss = 10f;

    private Transform player;
    private int enemyNumber = 0;
    private float spawnFrequency = 0f; // Frecuency of enemy spawn
    private float spawnWait = 0f;    // Internal counter for spawn frequency
    private bool isReady = false;

    private void Start()
    {
        player = GameObject.FindWithTag("Player").transform;
        Invoke("SetReady", 2f);
    }

    private void Update()
    {
        if(!isReady || gameState.isGameOver || gameState.isPaused)
        {
            return;
        }

        if (Timer.current.time > timeBossSpawn && GameObject.FindWithTag("Boss") == null)
        {
            SpawnBoss();
            InvokeRepeating("SpawnEnemies", 0f, spawnFrequencyWithBoss);
        }

        if (spawnWait >= spawnFrequency && GameObject.FindWithTag("Boss") == null)
        {
            SpawnEnemies();
            spawnWait = 0f;
        }

        spawnFrequency = Mathf.Max(0.5f, 5f - (Timer.current.time) * 0.05f); // Asure that the spawn frequency is never lower than 0.5

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

    private void SpawnBoss()
    {
        GameObject currentBoss = Instantiate(boss, bossSpawnPoint.position, Quaternion.identity);
        currentBoss.name = "Boss";
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
