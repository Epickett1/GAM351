using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this value to control movement speed
    public float rotationSpeed = 100f; // Adjust this value to control rotation speed
    public float hoverHeight = 1f; // Adjust this value to control hover height
    public float hoverSpeed = 1f; // Adjust this value to control hover speed
    public float hoverAmplitude = 0.1f; // Adjust this value to control hover amplitude
    public float terrainHeightOffset = 0.5f; // Adjust this value to control the height offset from terrain

    private Terrain terrain;
    private float originalY;
    private float hoverOffset;

    void Start()
    {
        terrain = Terrain.activeTerrain;
        originalY = transform.position.y;
    }

    void Update()
    {
        // Hover effect
        Hover();

        // Movement controls
        Move();

        // Rotation controls
        Rotate();
    }

    void Hover()
    {
        // Calculate hoverOffset using sine function to create a hover effect
        hoverOffset = Mathf.Sin(Time.time * hoverSpeed) * hoverAmplitude;

        // Get the current terrain height under the car
        float terrainHeight = terrain.SampleHeight(transform.position);

        // Apply hover effect to car's Y position relative to terrain height
        Vector3 newPos = transform.position;
        newPos.y = originalY + hoverHeight + hoverOffset + terrainHeight + terrainHeightOffset;
        transform.position = newPos;
    }

    void Move()
    {
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(Vector3.forward * moveAmount);
    }

    void Rotate()
    {
        float rotateAmount = Input.GetAxis("Horizontal") * rotationSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, rotateAmount);
    }
}

