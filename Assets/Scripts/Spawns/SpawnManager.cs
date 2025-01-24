using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy; // Prefab del enemigo
    public GameObject DragonBoss; // Prefab del jefe
    public Transform spawnDragonPoint; // Punto de spawn del jefe
    public Transform[] spawnPoints; // Puntos de spawn para enemigos
    public GameObject spawnedEnemies; // Contenedor de enemigos generados
    public TMP_Text numRonda;

    public int round = 1; // Ronda actual
    public float spawnDelay = 0.3f; // Tiempo entre cada aparición de enemigos
    [SerializeField] private float delayRound = 2f; // Retraso para cambiar de ronda

    private int currentRound = 0; // Control de rondas activas
    private bool roundOver = false; // Controla si la ronda ha terminado
    private bool bossSpawned = false; // Controla si el jefe ha sido invocado


    void Start()
    {
        numRonda.text = round.ToString();
    }

    void Update()
    {
        // Si la ronda ha cambiado, iniciar el spawn de enemigos o del jefe
        if (currentRound != round)
        {
            if (round >= 10 && !bossSpawned) // Invocar jefe a partir de la ronda 10
            {
                SpawnBoss();
                bossSpawned = true; // Marcar que el jefe ya ha sido invocado
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
        // Verificar si ya no hay enemigos vivos y la ronda no ha terminado
        if (spawnedEnemies != null && spawnedEnemies.transform.childCount == 0 && !roundOver)
        {
            roundOver = true;
            Invoke("ChangeRound", delayRound);
            Debug.Log("Todos los enemigos han sido eliminados. Preparando la siguiente ronda...");
        }
    }

    void ChangeRound()
    {
        // Avanzar a la siguiente ronda
        if (roundOver)
        {
            round++;
            numRonda.text = round.ToString();
            roundOver = false;

            // Resetear el estado del jefe si se superaron 10 rondas
            if (round % 10 != 0)
            {
                bossSpawned = false;
            }

            Debug.Log($"Se ha iniciado la ronda {round}");
        }
    }

    IEnumerator SpawnEnemiesGradually()
    {
        int enemiesPerRound = round * 2; // Número total de enemigos por ronda
        int enemiesSpawned = 0; // Contador de enemigos generados

        roundOver = false;

        while (enemiesSpawned < enemiesPerRound)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                if (enemiesSpawned >= enemiesPerRound) break;

                // Generar un desplazamiento aleatorio en X y Z
                float randomOffsetX = Random.Range(0f, 1f);
                float randomOffsetZ = Random.Range(0f, 1f);
                Vector3 offset = new Vector3(randomOffsetX, 0, randomOffsetZ);
                Vector3 spawnPosition = spawnPoint.position + offset;

                // Instanciar enemigo
                GameObject enemyInstance = Instantiate(enemy, spawnPosition, Quaternion.identity);
                enemyInstance.name = $"Enemigo Ronda {round} No {enemiesSpawned + 1}";
                enemyInstance.transform.SetParent(spawnedEnemies.transform);

                enemiesSpawned++; // Incrementar el contador de enemigos generados

                // Esperar antes de generar el siguiente enemigo
                yield return new WaitForSeconds(spawnDelay);
            }
        }
    }

    void SpawnBoss()
    {
        // Instanciar al jefe en el punto de spawn específico
        GameObject dragonInstance = Instantiate(DragonBoss, spawnDragonPoint.position, Quaternion.identity);
        dragonInstance.name = "BossDragon";
        dragonInstance.transform.SetParent(spawnedEnemies.transform);

        Debug.Log("¡El jefe ha aparecido!");
    }
}
