using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float speed;
    public float damage;
    Vector3 target;

    public BulletScript(float damage)
    {
        this.damage = damage;
    }
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
