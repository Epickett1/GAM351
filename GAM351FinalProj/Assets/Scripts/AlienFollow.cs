using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AlienFollow : MonoBehaviour
{
    public NavMeshAgent alien;
    public Transform Player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        alien.SetDestination(Player.position);
    }
}
