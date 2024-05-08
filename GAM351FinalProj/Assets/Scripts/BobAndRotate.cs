using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobAndRotate : MonoBehaviour
{
    public float bobSpeed = 1f; 
    public float bobHeight = 0.3f;
    public float rotationSpeed = 7f; 

    private Vector3 startPos;
    private float yOffset;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
        // Calculate the vertical offset
        yOffset = Mathf.Sin(Time.time * bobSpeed) * bobHeight;

        transform.localPosition = startPos + new Vector3(0f, yOffset, 0f);

        transform.rotation = Quaternion.Euler(0f, Time.time * rotationSpeed, 0f);
    }
}
