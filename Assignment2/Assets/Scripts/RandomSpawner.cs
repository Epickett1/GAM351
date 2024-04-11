using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject ship_1Prefab;
    public GameObject ship_2Prefab;
    public GameObject ship_3Prefab;
    private int totalSpawned = 0;

    // Update is called once per frame
    void Update()
    {
        if (totalSpawned < 9)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
                Instantiate(ship_1Prefab, randomSpawnPosition, Quaternion.identity);
                totalSpawned++;
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
                Instantiate(ship_2Prefab, randomSpawnPosition, Quaternion.identity);
                totalSpawned++;
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
                Instantiate(ship_3Prefab, randomSpawnPosition, Quaternion.identity);
                totalSpawned++;
            }

        }
    }
}
