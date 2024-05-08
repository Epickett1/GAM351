using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp_Spawn : MonoBehaviour
{
    public GameObject[] objectsToSpawn;
    public Transform spawnArea;
    public int maxObjects = 10;
    public float spawnInterval = 2f; // Adjust this value to change the spawn frequency

    private int objectsSpawned = 0;

    void Start()
    {
        // Call SpawnObject repeatedly with a shorter interval
        InvokeRepeating("SpawnObject", 0f, spawnInterval);
    }

    void SpawnObject()
    {
        if (objectsSpawned < maxObjects)
        {
            // Generate random positions within the spawnArea
            float randomX = Random.Range(-45f, 45f);
            float randomZ = Random.Range(-90f, 90f);

            // Calculate spawnPosition within the spawnArea
            Vector3 spawnPosition = new Vector3(
                spawnArea.position.x + randomX,
                spawnArea.position.y,
                spawnArea.position.z + randomZ
            );

            GameObject objectToSpawn = objectsToSpawn[Random.Range(0, objectsToSpawn.Length)];
            Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

            objectsSpawned++;
        }
        else
        {
            // Stop spawning when maxObjects is reached
            CancelInvoke("SpawnObject");
        }
    }
}
