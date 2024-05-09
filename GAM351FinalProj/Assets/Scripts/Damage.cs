using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    public float damage;

    public bool destroyOnContact;

    public List<string> ignoreTags = new List<string>();

    bool ignore = false;

    private void OnCollisionEnter(Collision collision)
    {
        Damageable dm = collision.gameObject.GetComponent<Damageable>();
        if (dm != null )
        {
            foreach (string tag in ignoreTags)
            {
                if (collision.gameObject.CompareTag(tag))
                {
                    ignore = true;
                }
            }
            if (!ignore)
            {
                dm.Damage(damage);
            }
        }
        if (!ignore)
        {
            if (destroyOnContact)
            {
                Destroy(gameObject);
            }
        }
        ignore = false;
    }
}
