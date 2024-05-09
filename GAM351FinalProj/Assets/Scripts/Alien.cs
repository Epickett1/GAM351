using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Alien : MonoBehaviour
{
    public Image healthBar; 
    Animator animator;
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
        yield return new WaitForSeconds(.2f);
        animator.SetBool("hit", false);
    }

    public void Die()
    {
        animator.SetBool("dead", true);
        StartCoroutine(Despawn());
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(4f);
        Destroy(gameObject);
    }


}
