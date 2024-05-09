using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{
    public Image healthBar;
    [Header("Spawn Rate (1/?)")]
    [Range(1, 20)]
    public int spawnRate;
    public List<GameObject> powerUps = new List<GameObject>();
    
    Animator animator;
    bool spawned = false;
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    public void Hit(float health, float maxHealth)
    {
        animator.SetBool("hit", true);
        float tempX = Mathf.Clamp01(health / maxHealth);
        healthBar.rectTransform.localScale = new Vector3(tempX, healthBar.rectTransform.localScale.y, healthBar.rectTransform.localScale.z);
        healthBar.color = Color.Lerp(Color.red, Color.green, tempX);
        StartCoroutine(EndAnim());
    }

    IEnumerator EndAnim()
    {
        yield return new WaitForSeconds(.3f);
        animator.SetBool("hit", false);
    }

    public void Die()
    {
        animator.SetBool("dead", true);
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(3.5f);
        SpawnPowerUp();
        yield return new WaitForSeconds(.5f);
        Destroy(gameObject);
    }

    void SpawnPowerUp()
    {
        if (!spawned)
        {
            spawned = true;
            int chance = Random.Range(1, spawnRate + 1);
            if (chance == 1)
            {
                int rand = Random.Range(0, powerUps.Count);
                Instantiate(powerUps[rand], (transform.position + new Vector3(0f, 2f, 0f)), Quaternion.identity);
            }
        }
    }
}
