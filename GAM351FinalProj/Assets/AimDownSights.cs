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
    Transform lookAtStart;
    CinemachineFreeLook cam;
    bool aimedIn = false;

    void Start()
    {
        cam = GetComponent<CinemachineFreeLook>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void AimIn()
    {
        if (!aimedIn)
        {
            aimedIn = true;
            lookAtStart = lookAt;
            cam.m_Lens.FieldOfView *= .5f;
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
            cam.m_Lens.FieldOfView *= 2f;
            cam.m_YAxis.m_MaxSpeed *= 100f / adsSensitivity;
            cam.m_XAxis.m_MaxSpeed *= 100f / adsSensitivity;
        }

    }
}
