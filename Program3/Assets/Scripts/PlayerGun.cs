using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGun : MonoBehaviour
{
    public float lifespan = 3f;
    public float fireRate = 1f;
    public GameObject rubblePrefab;
    public GameObject targetPrefab;

    private bool canShoot = true;

    private void Start()
    {
        Destroy(gameObject, lifespan);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        Instantiate(gameObject, transform.position, transform.rotation);
        canShoot = false;
        Invoke("ResetShoot", 1f / fireRate);
    }

    private void ResetShoot()
    {
        canShoot = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Barrel"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(rubblePrefab, collision.transform.position, collision.transform.rotation);
        }
        else if (collision.gameObject.CompareTag("Target"))
        {
            // Play animation here
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

