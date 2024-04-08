using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float shakeThreshold;
    public float shakeAmount;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // Hint: The global static variable "Terrain.activeTerrain" 
        // may be helpful or have useful methods for user here or in
        // other scripts.
        Terrain terrain = Terrain.activeTerrain;

        Vector3 position = transform.position;

        // set the game object's translation (not an increment)
        transform.position = position;

        if (Input.GetKey(KeyCode.W))    // Move forward
        {

        }
        if (Input.GetKey(KeyCode.S))    // Move backward
        {

        }

        if (Mathf.Abs(rb.velocity.magnitude) < shakeAmount)    // Handle idle shake
        {

            Vector3 shakePos = transform.position;
            shakePos.x += Random.Range(-shakeAmount, shakeAmount);
            shakePos.z += Random.Range(-shakeAmount, shakeAmount);
            transform.position = shakePos;
        }
    }
}
