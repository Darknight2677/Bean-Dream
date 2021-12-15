using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;

    public int maxHealth = 100;
    public int currentHealth;

    public EnemyAI AI;

    //Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        AI = GetComponent<EnemyAI>();
        //rb = GetComponent<Rigidbody2D>();
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
        //rb.velocity = new Vector2(-5f, 0);
        if (currentHealth <= 0)
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
