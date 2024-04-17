using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public List<Transform> camPositions;
    public List<Transform> cars;

    private Transform targetPos;
    private Transform targetLook;
    private int index = 0;

    void Start()
    {
        targetPos = camPositions[0];
        targetLook = cars[0];
    }

    void LateUpdate()
    {
        transform.position = targetPos.position;
        transform.LookAt(targetLook);
        if (Input.GetKeyDown(KeyCode.C))
        {
            index++;
            if (index >= camPositions.Count)
            {
                index = 0;
            }
            targetPos = camPositions[index];
            targetLook = cars[index];
        }
    }
}
