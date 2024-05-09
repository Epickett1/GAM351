using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AlienFollow : MonoBehaviour
{
    NavMeshAgent alien;
    Transform player;

    // Start is called before the first frame update
    void Start()
    {
        alien = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        alien.SetDestination(player.position);
    }
}
