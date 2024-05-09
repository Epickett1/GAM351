using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivationArea : MonoBehaviour
{
    public List<GameObject> objects = new List<GameObject>();

    private void Start()
    {
        foreach (GameObject obj in objects)
        {
            obj.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            foreach (GameObject obj in objects)
            {
                obj.SetActive(true);
            }
        }
    }
}
