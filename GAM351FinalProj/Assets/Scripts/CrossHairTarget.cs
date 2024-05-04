using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHairTarget : MonoBehaviour
{
    new Camera camera;
    Ray ray;
    RaycastHit hitInfo;
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        ray.origin = camera.transform.position;
        ray.direction = camera.transform.forward;
        Physics.Raycast(ray, out hitInfo);
        transform.position = hitInfo.point;
    }
}
