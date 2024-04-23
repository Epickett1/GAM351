using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
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
        if (transform.position == target)
            Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Die die = collision.gameObject.GetComponent<Die>();
        Explode explode = collision.gameObject.GetComponent<Explode>();

        if (die != null)
        {
            die.Death();
        }

        if (explode != null)
        {
            explode.Explosion();
        }
        Destroy(gameObject);
    }
}
