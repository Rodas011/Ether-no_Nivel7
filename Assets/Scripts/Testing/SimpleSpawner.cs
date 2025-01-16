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

    private int enemyNumber = 0;
    private float spawnFrequency = 0f; // Frecuency of enemy spawn
    private float spawnWait = 0f;    // Internal counter for spawn frequency

    private void Update()
    {
        if(gameState.isGameOver || gameState.isPaused)
        {
            return;
        }

        if (Timer.current.time > timeBossSpawn && GameObject.FindWithTag("Boss") == null)
        {
            SpawnBoss();
        }

        if (spawnWait >= spawnFrequency && GameObject.FindWithTag("Boss") == null)
        {
            SpawnEnemies();
            spawnWait = 0f;
        }

        spawnFrequency = Mathf.Max(0.5f, 5f - (Timer.current.time) * 0.05f); // Asure that the spawn frequency is never lower than 0.5
        Debug.Log("Spawn frequency: " + spawnFrequency);

        spawnWait += Time.deltaTime;
    }

    private void SpawnEnemies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            float randomX = Random.Range(1f, 2f);
            float randomZ = Random.Range(1f, 2f);
            Vector3 offset = new Vector3(randomX, spawnPoint.position.y, randomZ);
            Vector3 spawnPosition = spawnPoint.position + offset;

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
}
