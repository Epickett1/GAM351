using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestroy : MonoBehaviour
{
    public float timedDestroy;
    float time;

    void Update()
    {
        time += Time.deltaTime;
        if (time >= timedDestroy)
            Destroy(gameObject);
    }
}
