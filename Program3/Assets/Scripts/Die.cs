using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Die : MonoBehaviour
{
    Animator animator;
    List<string> deathAnims = new List<string> { "dead1", "dead2" };
    bool dead = false;
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void Death()
    {
        if (!dead) // so they don't die twice
        {
            int rand = Random.Range(0, deathAnims.Count);
            animator.SetBool(deathAnims[rand], true);
            dead = true;
        }
    }
}
