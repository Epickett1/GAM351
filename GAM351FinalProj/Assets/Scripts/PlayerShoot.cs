using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public bool isShooting = false;

    public GameObject bulletPrefab;
    public float timeBtwShots = 0.3f;

    private float time = 0f;

    void Update()
    {
        time += Time.deltaTime;
    }
    public void StartShoot()
    {
        if (time >= timeBtwShots)
        {
            isShooting = true;
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            time = 0f;
        }
    }

    public void StopShoot()
    {
        isShooting = false;
    }
}
