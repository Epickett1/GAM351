using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AimDownSights : MonoBehaviour
{
    public Transform lookAt;

    [Header("ADS Sensitivity (%)")]
    [Range(0.1f, 100.0f)]
    public float adsSensitivity = 50.0f;
    public float transitionSpeed = 200f;

    Transform lookAtStart;
    CinemachineFreeLook cam;
    float targetView;
    bool aimedIn = false;

    void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();
        targetView = cam.m_Lens.FieldOfView * .5f;
    }

    // Update is called once per frame
    void Update()
    {
        float currView = cam.m_Lens.FieldOfView;

        // zoom in
        if (aimedIn && currView > targetView){
            cam.m_Lens.FieldOfView = currView - (Time.deltaTime * transitionSpeed);
            if (cam.m_Lens.FieldOfView <= targetView) 
            {
                cam.m_Lens.FieldOfView = targetView;
            }
        }

        // zoom out
        if (!aimedIn && currView < (targetView * 2))
        {
            cam.m_Lens.FieldOfView = currView + (Time.deltaTime * transitionSpeed);
            if (cam.m_Lens.FieldOfView >= (targetView * 2))
            {
                cam.m_Lens.FieldOfView = (targetView * 2);
            }
        }
    }
    public void AimIn()
    {
        if (!aimedIn)
        {
            aimedIn = true;
            lookAtStart = lookAt;
            cam.m_YAxis.m_MaxSpeed *= adsSensitivity / 100f;
            cam.m_XAxis.m_MaxSpeed *= adsSensitivity / 100f;
        }

    }

    public void AimOut()
    {
        if (aimedIn)
        {
            aimedIn = false;
            lookAt = lookAtStart;
            cam.m_YAxis.m_MaxSpeed *= 100f / adsSensitivity;
            cam.m_XAxis.m_MaxSpeed *= 100f / adsSensitivity;
        }

    }
}
