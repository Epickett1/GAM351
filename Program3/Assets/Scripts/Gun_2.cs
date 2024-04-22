using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    public Transform bulletSpawnPoint;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    public float fireRate = 1f;
    private float lastFireTime;

    void Update()
    {
        if (Time.time > lastFireTime + 1f / fireRate)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                FireBullet();
                lastFireTime = Time.time;
            }
        }
    }

    void FireBullet()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().velocity = bulletSpawnPoint.forward * bulletSpeed;
    }
}
