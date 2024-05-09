using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;

    public bool destroyOnContact;

    private void OnCollisionEnter(Collision collision)
    {
        Damageable dm = collision.gameObject.GetComponent<Damageable>();
        if (dm != null )
        {
            dm.Damage(damage);
        }
        if ( destroyOnContact )
        {
            Destroy(gameObject);
        }
    }
}
