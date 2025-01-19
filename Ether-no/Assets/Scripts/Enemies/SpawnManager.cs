using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    public int round = 1;
    public GameObject spawnedEnemies;
    public float spawnDelay = 0.5f; // Tiempo entre cada aparición de enemigos
    bool roundOver = false;

    [SerializeField] float delayRound;

    private int roundAct = 0;
    private GameObject [] enemigoSpawneados = new GameObject[10];

    void Update()
    {

        if (roundAct != round)
        {
            StartCoroutine(SpawnEnemiesGradually());
            //SpawnEnemies();
            roundAct = round;
        }
    }

    void LateUpdate()
    {

        if (spawnedEnemies != null && spawnedEnemies.transform.childCount == 0 && roundOver == false)
        {

            roundOver = true;
            Invoke ("ChangeRound",delayRound);
            Debug.Log("El padre ya no tiene hijos. Ejecutando acción...");
        }

    }

    void ChangeRound()
    {

        if (roundOver == true)
        {
            round++;
            //roundOver = false;

            print ("Se subio de ronda del change round");
        }

    }

    IEnumerator SpawnEnemiesGradually()
    {
        int objEnemyPerRound = round * 2; // Número total de enemigos a generar en esta ronda
        int enemigosGenerados = 0;

        roundOver = false;
        
        while (enemigosGenerados < objEnemyPerRound)
        {
            foreach (Transform spawnPoint in spawnPoints)
            {
                if (enemigosGenerados >= objEnemyPerRound) break;

                // Generar un desplazamiento aleatorio en X y Z
                float numberRandomX = Random.Range(0f, 1f);
                float numberRandomZ = Random.Range(0f, 1f);
                Vector3 offset = new Vector3(numberRandomX, spawnPoint.position.y, numberRandomZ);
                Vector3 spawnPosition = spawnPoint.position + offset;

                // Instanciar enemigo
                GameObject objEnemigo = Instantiate(enemy, spawnPosition, Quaternion.identity);
                objEnemigo.name = "Enemigo Ronda " + round + " No " + (enemigosGenerados + 1);
                objEnemigo.transform.SetParent(spawnedEnemies.transform);

                enemigosGenerados++; // Incrementar el contador de enemigos generados

                // Esperar antes de generar el siguiente enemigo
                yield return new WaitForSeconds(spawnDelay);
                
            }
        }
    }
    void SpawnEnemies()
    {
        roundOver = false;

        foreach (Transform spawnPoint in spawnPoints)
        {
            int objEnemyPerRound = round * 2;

            for (int indiceEnemigo = 0; indiceEnemigo < spawnPoint.childCount; indiceEnemigo++ )
            {
                GameObject enemigoSpawneados = spawnPoint.GetChild(indiceEnemigo). gameObject;
            }

            for (int numero = 1; numero <= objEnemyPerRound; numero++)
            {

                float numeroRandomX = Random.Range(0f, 1f);
                float numeroRandomZ = Random.Range(0f, 1f);
                Vector3 offset = new Vector3(numeroRandomX, spawnPoint.position.y, numeroRandomZ);
                Vector3 spawnPosition = spawnPoint.position + offset;


                GameObject enemigo = Instantiate(enemy, spawnPosition, Quaternion.identity);
                enemigo.name = "Enemigo Ronda " + round + " No " + numero;
                enemigo.transform.SetParent(spawnedEnemies.transform);
                
            }
        }
    }
}
