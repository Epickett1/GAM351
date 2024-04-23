using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosion;
    public GameObject debris;
    Rigidbody rb;
    MeshRenderer mr;
    MeshCollider mc;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponent<MeshRenderer>();
        mc = GetComponent<MeshCollider>();
    }

    public void Explosion()
    {
        Instantiate(explosion, transform.position, Quaternion.identity);
        rb.useGravity = false;
        mr.enabled = false;
        mc.enabled = false;
        Instantiate(debris, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
