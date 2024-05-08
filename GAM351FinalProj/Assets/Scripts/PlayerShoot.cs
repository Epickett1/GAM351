using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public PlayerController player;
    public BulletScript bulletPrefab;
    public bool isShooting = false;

    private float time = 0f;
    void Update()
    {
        time += Time.deltaTime;
    }
    public void StartShoot()
    {
        if (time >= player.fireRate)
        {
            isShooting = true;
            bulletPrefab.damage = player.gunDamage;
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            time = 0f;
        }
    }

    public void StopShoot()
    {
        isShooting = false;
    }
}
