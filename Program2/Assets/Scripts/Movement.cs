using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float turnSpeed;
    public float forwardSpeed;
    public float hoverHeight;
    public float shakeThreshold;
    public float shakeAmount;

    private Rigidbody rb;
    private Terrain terrain;
    private float terrainHeight;
    private Vector3 desiredPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        terrain = Terrain.activeTerrain;
    }

    void FixedUpdate()
    {
        // Calc float height
        terrainHeight = terrain.SampleHeight(transform.position);
        float floatHeight = terrainHeight + hoverHeight;
        float heightDifference = floatHeight - transform.position.y;

        // Calculate the desired position
        desiredPosition = new Vector3(transform.position.x, floatHeight, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, desiredPosition, 10 * Time.fixedDeltaTime);

        // Handle movement
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Rotate(Vector3.up * horizontal * turnSpeed * Time.fixedDeltaTime);
        transform.Translate(Vector3.forward * vertical * forwardSpeed * Time.fixedDeltaTime);


        if (Mathf.Abs(rb.velocity.magnitude) < shakeThreshold)
        {
            // Apply shaking effect
            Vector3 shakePos = transform.position;
            shakePos.x += Random.Range(-shakeAmount, shakeAmount);
            shakePos.z += Random.Range(-shakeAmount, shakeAmount);
            transform.position = shakePos;
        }
    }
}