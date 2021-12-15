using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;

    public EnemyAI AI;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        AI = GetComponent<EnemyAI>();
    }

    private void Update()
    {
        if(currentHealth >= 0)
        {
            AI.enabled = true;
        }
    }
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        animator.SetTrigger("Hurt");

        if(currentHealth <= 0)
        {
            Die();
            AI.enabled = false;
        }
    }

    void Die()
    {
        Debug.Log("Enemy died!");

        animator.SetBool("IsDead", true);

        GetComponent<BoxCollider2D>().enabled = false;
        this.enabled = false;
        GetComponent<BoxCollider2D>().enabled = false;
    }
}
