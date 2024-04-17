using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover2 : MonoBehaviour
{

    void Start()
    {
    }

    public float speed = 45f;
    public float rotationSpeed = 13f;

    void Update()
    {
        Vector3 position = transform.position;

        transform.position = position;

        if (Input.GetKey(KeyCode.W))
        { transform.Translate(0, 0, 45f * Time.deltaTime); }

        if (Input.GetKey(KeyCode.D))
        { transform.Rotate(0, 5f * Time.deltaTime, 0); }
    }
}
