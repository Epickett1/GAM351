using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform laserSpawnPoint;
    public GameObject laserPrefab;
    public float laserSpeed = 10;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var laser = Instantiate(laserPrefab, laserSpawnPoint.position, laserSpawnPoint.rotation);
            laser.GetComponent<Rigidbody>().velocity = laserSpawnPoint.forward * laserSpeed;
        }
    }
}