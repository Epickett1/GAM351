using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneController : MonoBehaviour
{
    public PlayerController playerController;
    public GameObject cam;
    public GameObject cutsceneCheck;
    public GameObject cutsceneCam;
    void Start()
    {
        cutsceneCheck.SetActive(false);
        Deactivate();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || cutsceneCheck.activeSelf)
        {
            Activate();
        }
    }

    void Activate()
    {
        playerController.enabled = true;
        Destroy(cutsceneCam);
        cam.SetActive(true);
    }

    void Deactivate()
    {
        playerController.enabled = false;
        cam.SetActive(false);
    }
}
