using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : MonoBehaviour
{
    public GameObject explosion;
    public GameObject debris;

    public void Explosion()
    {
       Instantiate(explosion, transform.position, Quaternion.identity);
       StartCoroutine(AfterExplosion());
    }

    IEnumerator AfterExplosion()
    {
        yield return new WaitForSeconds(2);
        Instantiate(debris, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
