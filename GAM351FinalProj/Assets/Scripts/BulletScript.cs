using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    Vector3 target;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("PlayerTarget").GetComponent<Transform>().position;   
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
        if (transform.position == target) DestroyBullet();
    }

    private void OnCollisionEnter(Collision collision)
    {
        
    }

    public void DestroyBullet()
    {
        Destroy(gameObject);
    }
}
