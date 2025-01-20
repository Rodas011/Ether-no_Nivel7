using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPositionController : MonoBehaviour
{
    public float distanceFromCamera = 0.5f;
    private Transform[] spawnPoints;
    private float cameraDistance;

    private void Start()
    {
        // Obtains the distance from the camera to the player
        CameraController cameraController = Camera.main.GetComponent<CameraController>();
        cameraDistance = cameraController.distance;

        // Initialize the spawn points array with the children of the current object
        spawnPoints = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            spawnPoints[i] = transform.GetChild(i);
        }
    }

    private void Update()
    {
        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("There is no spawn points");
            return;
        }
        updateSpawnPoints();

    }

    private void updateSpawnPoints()
    {
        Vector3 left = Camera.main.ViewportToWorldPoint(new Vector3(0f - distanceFromCamera, 0.5f, cameraDistance));
        left.y = 0;
        Vector3 right = Camera.main.ViewportToWorldPoint(new Vector3(1f + distanceFromCamera, 0.5f, cameraDistance));
        right.y = 0;
        Vector3 down = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0f - distanceFromCamera, cameraDistance));
        down.y = 0;
        Vector3 up = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 1f + distanceFromCamera, cameraDistance));
        up.y = 0;

        // Relative positions to the camera
        Vector3[] viewportPositions = new Vector3[] { left, right, down, up };

        // Assign positions cyclically
        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int positionIndex = i % viewportPositions.Length;
            spawnPoints[i].position = viewportPositions[positionIndex];
        }
    }

}
