using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_2 : MonoBehaviour
{
    public float lifespan = 3f;
    public GameObject barrelPrefab;
    public GameObject rubblePrefab;
    public GameObject targetPrefab;

    void Awake()
    {
        Destroy(gameObject, lifespan);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == barrelPrefab)
        {
            Instantiate(rubblePrefab, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else if (other.gameObject == targetPrefab)
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
