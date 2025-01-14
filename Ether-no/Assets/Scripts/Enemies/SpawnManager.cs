using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject enemy;
    public Transform[] spawnPoints;
    public int round = 1;

    private int roundAct = 0;
    private GameObject [] enemigoSpawneados = new GameObject[10];

    void Update()
    {

        if (roundAct != round)
        {
            SpawnEnemies();
            roundAct = round;
        }
    }

    void SpawnEnemies()
    {
        foreach (Transform spawnPoint in spawnPoints)
        {
            int enemigosPorRonda = round * 2;

            for (int indiceEnemigo = 0; indiceEnemigo < spawnPoint.childCount; indiceEnemigo++ )
            {
                GameObject enemigoSpawneados = spawnPoint.GetChild(indiceEnemigo). gameObject;
            }

            for (int numero = 1; numero <= 2; numero++)
            {

                float numeroRandomX = Random.Range(0f, 0.9f);
                float numeroRandomZ = Random.Range(0f, 0.9f);
                Vector3 offset = new Vector3(numeroRandomX, spawnPoint.position.y, numeroRandomZ);
                Vector3 spawnPosition = spawnPoint.position + offset;


                GameObject enemigo = Instantiate(enemy, spawnPosition, Quaternion.identity);
                enemigo.name = "Enemigo Ronda " + round + " No " + numero;
            }
        }
    }
}
