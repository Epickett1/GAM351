using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float impulseForce  = 170000.0f;
    public float impulseTorque = 3000.0f;

    [Range(1, 5)]
    public int kickOptions = 5; 
    public float kickForce = 500f;
    public float kickDistance = 3f;
    public LayerMask kickMask;

    public GameObject hero;

    Animator animController;
    Rigidbody rigidBody;
    List<string> kickAnims = new List<string> { "Kick1", "Kick2", "Kick3", "Kick4", "Kick5" };
    bool kicking = false;

    AudioManager audioManager;

    private void Awake() {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }


    // Start is called before the first frame update
    void Start()
    {
        // get references to the animation controller of hero
        // character and player's corresponding rigid body
        animController = hero.GetComponent<Animator> ();
        rigidBody      = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        // W/A/S/D input as a combined rotation and movement vector
        Vector3 input = new Vector3(0, Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        // allow movement when input detected and not crouching
        if (input.magnitude > 0.001 && !animController.GetBool ("Crouch") && !kicking)
        {
            // play footstep sound 
            audioManager.PlayFoley(audioManager.footsteps);
            // rotations are about y axis
            rigidBody.AddRelativeTorque(new Vector3(0, input.y * impulseTorque * Time.deltaTime, 0));
            // motion is forward/backward (about z axis)
            rigidBody.AddRelativeForce(new Vector3(0, 0, input.z * impulseForce * Time.deltaTime));

            animController.SetBool("Walk", true);
        }
        else
        {
            animController.SetBool("Walk", false);

            // crouching with 'C' key (only when not moving)
            if (Input.GetKey(KeyCode.C))
                animController.SetBool("Crouch", true);
            else
                animController.SetBool("Crouch", false);
        }

        // Only allow kick when not moving and not crouching
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!animController.GetBool("Crouch") && !animController.GetBool("Walk") && !kicking)
            {
                int rand = Random.Range(0, kickOptions);
                animController.SetBool(kickAnims[rand], true);
                kicking = true;
                StartCoroutine(KickObjects());
                StartCoroutine(PlayKick(rand));
                
            }
        }
    }

    IEnumerator PlayKick(int rand)
    {
        yield return new WaitForSeconds(1);
        kicking = false;
        animController.SetBool(kickAnims[rand], false);
    }

    IEnumerator KickObjects()
    {
        yield return new WaitForSeconds(.5f);
        // Cast a ray in the forward direction from the player
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, kickDistance, kickMask))
        {
            // Get the rigidbody component of the detected object
            Rigidbody rb = hit.collider.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Calculate the kick direction
                Vector3 kickDirection = hit.collider.transform.position - transform.position;
                kickDirection.Normalize();

                // Apply the kick force to the object's rigidbody
                rb.AddForce(kickDirection * kickForce, ForceMode.Impulse);
            }
        }
    }
}
