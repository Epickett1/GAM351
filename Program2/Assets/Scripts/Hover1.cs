using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover1 : MonoBehaviour
{

    void Start()
    {
    }

    public float speed = 15f;
    public float rotationSpeed = 15f;

    void Update()
    {
        Vector3 position = transform.position;

        transform.position = position;

        if (Input.GetKey(KeyCode.W))
        { transform.Translate(0, 0, 15f * Time.deltaTime); }

        if (Input.GetKey(KeyCode.D))
        { transform.Rotate(0, 15f * Time.deltaTime, 0); }
    }
}
