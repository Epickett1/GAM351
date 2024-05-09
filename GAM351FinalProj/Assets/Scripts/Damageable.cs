using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth;
    float health;

    [Header("Sounds")]
    public AudioSource hit;
    public AudioSource heal;
    public AudioSource death;

    [Header("Actions")]
    public UnityEvent<float, float> onDamageTaken;
    public UnityEvent<float, float> onHeal;
    public UnityEvent onDeath;

    private void Start()
    {
        health = maxHealth;
    }

    public void Damage(float damage)
    {
        if (health > 0)
        {
            health -= damage;
        }
        //hit.Play();
        onDamageTaken.Invoke(health, maxHealth);
        if (health <= 0){        // dead
            //death.Play();
            onDeath.Invoke();
        }
    }
    
    public void Heal(float healAmount)
    {
        if (health + healAmount > maxHealth) health = maxHealth;
        else health += healAmount;
        onHeal.Invoke(health, maxHealth);
    }
}
