using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover3 : MonoBehaviour
{
    
    void Start()
    {
    }

    public float speed = 5f;
    public float rotationSpeed = 50f;

    void Update()
    {
        Vector3 position = transform.position;

        transform.position = position;

        if (Input.GetKey(KeyCode.W))
        { transform.Translate(0, 0, 5f * Time.deltaTime); }

        if (Input.GetKey(KeyCode.D))
        { transform.Rotate(0, 50f * Time.deltaTime, 0); }
    }
}
