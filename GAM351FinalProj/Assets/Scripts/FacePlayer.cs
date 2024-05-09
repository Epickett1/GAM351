using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FacePlayer : MonoBehaviour
{
    Transform player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (player != null)
        {
            // Calculate the direction from this object to the player
            Vector3 directionToPlayer = player.position - transform.position;

            // Ensure the object stays upright (optional, depends on your object's orientation)
            directionToPlayer.y = 0f;

            // Rotate this object to face the player
            transform.rotation = Quaternion.LookRotation(directionToPlayer);
        }
    }
}
