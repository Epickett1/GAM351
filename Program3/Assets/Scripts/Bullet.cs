using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifespan = 3f;
    public GameObject barrelPrefab;
    public GameObject rubblePrefab;
    public GameObject targetPrefab;

    void Awake()
    {
        Destroy(gameObject, lifespan);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == barrelPrefab)
        {
            Instantiate(rubblePrefab, collision.transform.position, collision.transform.rotation);
            Destroy(collision.gameObject);
            Destroy(gameObject);

        }
        else if (collision.gameObject == targetPrefab)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}

