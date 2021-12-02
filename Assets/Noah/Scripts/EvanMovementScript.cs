﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvanMovementScript : MonoBehaviour
{
    bool grounded = false;
    Rigidbody2D rb2;
    SpriteRenderer sr;
    Animator a;

    public int maxHealth = 3;
    public int health;
    public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        a = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
<<<<<<< HEAD
        //a.SetFloat("yVelocity", rb2.velocity.y);
        //a.SetBool("Grounded", grounded);

        float horizValue = Input.GetAxis("Horizontal");

        //if (horizValue == 0)
        //{
            //a.SetBool("Moving", false);
        //}

        //if (horizValue > 0)
        //{
            //a.SetBool("Moving", true);
        //}

        //if (horizValue < 0)
        //{
            //a.SetBool("Moving", true);
        //}



=======
        float horizValue = Input.GetAxis("Horizontal");

>>>>>>> e6ff2fb09f16542661bf432d6dc2af6ac4da0a0b
        rb2.velocity = new Vector2(horizValue * 2, rb2.velocity.y);

        if (horizValue > 0)
        {
            sr.flipX = false;
        }

        if (horizValue < 0)
        {
            sr.flipX = true;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            //Destroy(collision.gameObject);
            if (health < 1)
            {
                transform.position = new Vector3(0, 0, 0);
                rb2.velocity = new Vector2(0, 0);
                healthBar.SetHealth(maxHealth);
                health = maxHealth;
            }
            healthBar.SetHealth(health);
        }

        if (collision.gameObject.tag == "enemyBullet")
        {
            health--;
            Destroy(collision.gameObject);
            if (health < 1)
            {
                transform.position = new Vector3(0, 0, 0);
                rb2.velocity = new Vector2(0, 0);
                healthBar.SetHealth(maxHealth);
                health = maxHealth;
            }
            healthBar.SetHealth(health);
        }
    }
}
