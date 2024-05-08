using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerController : MonoBehaviour
{
    [Header("Camera Settings")]
    public AimDownSights ads;
    public Transform camTarget;
    public float turnSpeed = 15f;
    new Camera camera;

    [Header("Movement")]
    public float speed = 10f;
    public float jumpStrength = 10f;
    public float gravity = 9.8f;
    float ogSpeed;

    [Header("Combat")]
    public PlayerShoot gun;
    public float gunDamage;
    public float fireRate;
    float ogGunDamage;
    float ogFireRate;

    bool poweredUp = false;
    float activeTime = 0f;
    CharacterController controller;
    AudioManager audioManager;
    
    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    private void Start()
    {
        controller = GetComponent<CharacterController>();
        camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        ogSpeed = speed;
        ogGunDamage = gunDamage;
        ogFireRate = fireRate;
    }

    void Update()
    {
        // ******** Camera ********
        float yCam = camera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yCam, 0), turnSpeed * Time.fixedDeltaTime);

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            ads.AimIn();
        }
        if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            ads.AimOut();
        }

        // ******** Player Movement ********
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

/*        if (controller.isGrounded)
        {
             movement.y = 0f;

            if (Input.GetButtonDown("Jump"))
            {
                movement.y = jumpStrength;
            }
        }
        else
        {
            // Apply gravity when not grounded
            movement.y -= gravity * Time.deltaTime;
        }*/

        controller.Move(transform.TransformDirection(movement) * speed * Time.deltaTime);

        // ******** Shooting ********
        if (Input.GetKey(KeyCode.Mouse0))
        {
            gun.StartShoot();
            // play laser sound
            if (poweredUp) {
                audioManager.PlaySFX(audioManager.heavyLaserSound);
            }
            else {
                audioManager.PlaySFX(audioManager.lightLaserSound);
            }
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            gun.StopShoot();
        }

        // ******** Power Ups ********
        if (poweredUp)
        {
            // play power up sound
            audioManager.PlaySFX(audioManager.powerupSound);
            activeTime -= Time.deltaTime;
            if (activeTime <= 0f)
            {
                DeactivatePowerUps();
            }
        }
    }


    public void SpeedUp(float timer)
    {
        speed *= 2f;
        poweredUp = true;
        activeTime = timer;
    }

    public void ShootFaster(float timer)
    {
        fireRate /= 2f;
        poweredUp = true;
        activeTime = timer;
    }

    public void ShootStronger(float timer)
    {
        gunDamage *= 2;
        poweredUp = true;
        activeTime = timer;
    }
    public void DeactivatePowerUps()
    {
        poweredUp = false;
        speed = ogSpeed;
        gunDamage = ogGunDamage;
        fireRate = ogFireRate;
    }
}

