using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public enum powerUpType
    {
        speedIncrease,
        fireRateIncrease,
        bulletDamageIncrease,
        heal
    }
    public powerUpType powerUp;
    public float activeTime = 5f;

    private void OnTriggerEnter(Collider other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.DeactivatePowerUps(); // power ups reset when new one is picked up
            if (powerUp == powerUpType.speedIncrease)
            {
                player.SpeedUp(activeTime);
            }
            else if (powerUp == powerUpType.fireRateIncrease)
            {
                player.ShootFaster(activeTime);
            }
            else if (powerUp == powerUpType.bulletDamageIncrease)
            {
                player.ShootStronger(activeTime);
            }
            else if (powerUp == powerUpType.heal)
            {
                player.Heal(activeTime);
            }
            Collected();
        }
    }
    void Collected()
    {
        Destroy(gameObject);
    }
}
