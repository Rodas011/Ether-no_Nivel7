using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public GameObject DragonBoss;
    public Transform spawnDragonPoint;
    public Transform[] spawnPoints;
    public GameObject spawnedEnemies;
    public TMP_Text numRonda;

    public int round = 1;
    public float spawnDelay = 0.3f;
    [SerializeField] private float delayRound = 2f;

    private int currentRound = 0;
    private bool roundOver = false;
    private bool bossSpawned = false;


    void Start()
    {
        numRonda.text = round.ToString();
    }

    void Update()
    {
        if (currentRound != round)
        {
            if (round >= 10 && !bossSpawned)
            {
                SpawnBoss();
                bossSpawned = true;
            }
            else
            {
                StartCoroutine(SpawnEnemiesGradually());
            }

            currentRound = round;
        }
    }

    void LateUpdate()
    {
        if (spawnedEnemies != null && spawnedEnemies.transform.childCount == 0 && !roundOver)
        {
            roundOver = true;
            Invoke("ChangeRound", delayRound);
        }
    }

    void ChangeRound()
    {
        // Next round
        if (roundOver)
        {
            round++;
            numRonda.text = round.ToString();
            roundOver = false;

            if (round % 10 != 0)
            {
                bossSpawned = false;
            }

        }
    }

    IEnumerator SpawnEnemiesGradually()
    {
        int enemiesPerRound = round * 2;
        int enemiesSpawned = 0;

        roundOver = false;

        while (enemiesSpawned < enemiesPerRound)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                if (enemiesSpawned >= enemiesPerRound) break;

                // generate random spawn
                float randomOffsetX = Random.Range(0f, 1f);
                float randomOffsetZ = Random.Range(0f, 1f);
                Vector3 offset = new Vector3(randomOffsetX, 0, randomOffsetZ);
                Vector3 spawnPosition = spawnPoint.position + offset;

                // Instancite Enemy
                GameObject enemyInstance = Instantiate(enemy, spawnPosition, Quaternion.identity);
                enemyInstance.name = $"Enemigo Ronda {round} No {enemiesSpawned + 1}";
                enemyInstance.transform.SetParent(spawnedEnemies.transform);

                enemiesSpawned++;

                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }

    void SpawnBoss()
    {
        // Instanciate Boss
        GameObject dragonInstance = Instantiate(DragonBoss, spawnDragonPoint.position, Quaternion.identity);
        dragonInstance.name = "BossDragon";
        dragonInstance.transform.SetParent(spawnedEnemies.transform);
    }
}
