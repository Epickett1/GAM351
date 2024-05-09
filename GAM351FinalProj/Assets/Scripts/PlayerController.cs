using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [Header("Camera Settings")]
    public AimDownSights ads;
    public Transform camTarget;
    public float turnSpeed = 15f;
    new Camera camera;

    [Header("Movement")]
    public float speed = 20f;
    public float jumpStrength = 1300f;
    float ogSpeed;

    [Header("Combat")]
    public PlayerShoot gun;
    public float gunDamage;
    public float fireRate;
    float ogGunDamage;
    float ogFireRate;

    [Header("Health")]
    public Image healthBar;

    bool alive = true;
    bool heal = false;
    bool poweredUp = false;
    float activeTime = 0f;
    CharacterController controller;
    AudioManager audioManager;
    
    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }
    Rigidbody rb;
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponentInChildren<Animator>();
        camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        ogSpeed = speed;
        ogGunDamage = gunDamage;
        ogFireRate = fireRate;
    }

    void Update()
    {
        if (alive)
        {
            // ******** Camera ********
            float yCam = camera.transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yCam, 0), turnSpeed * Time.fixedDeltaTime);

        // ******** Player Movement ********
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical).normalized;

        rb.MovePosition(transform.position + transform.TransformDirection(movement) * speed * Time.deltaTime);

        // ******** Jumping ********
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        }

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
            if (heal)
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

            rb.MovePosition(transform.position + transform.TransformDirection(movement) * speed * Time.deltaTime);

            // ******** Jumping ********
            if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.01f)
            {
                rb.AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
            }

            // ******** Shooting ********
            if (Input.GetKey(KeyCode.Mouse0))
            {
                gun.StartShoot();
            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {
                gun.StopShoot();
            }

            // ******** Power Ups ********
            if (poweredUp)
            {
                activeTime -= Time.deltaTime;
                if (heal)
                {
                    Damageable player = GetComponent<Damageable>();
                    player.Heal(0.1f);
                }
                if (activeTime <= 0f)
                {
                    DeactivatePowerUps();
                }
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
    
    public void Heal(float timer)
    {
        heal = true;
        poweredUp = true;
        activeTime = timer;
    }

    public void DeactivatePowerUps()
    {
        poweredUp = false;
        heal = false;
        speed = ogSpeed;
        gunDamage = ogGunDamage;
        fireRate = ogFireRate;
    }

    public void DrawHealth(float health, float maxHealth)
    {
        float healthRatio = Mathf.Clamp01(health / maxHealth);
        healthBar.rectTransform.localScale = new Vector3(healthBar.rectTransform.localScale.x, healthRatio, healthBar.rectTransform.localScale.z);
        healthBar.color = Color.Lerp(Color.red, Color.green, healthRatio);
    }

    public void Death()
    {
        animator.SetBool("death", true);
        alive = false;
    }
}


