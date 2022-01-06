﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerColliders : MonoBehaviour
{
    Rigidbody2D rb2;
    public PlayerMovement p;

    IEnumerator OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            p.health--;
            //rb.velocity = new Vector2(-JumpSpeed * 5f, JumpSpeed);
            if (p.health <= 0)
            {
                p.healthBar.SetHealth(p.maxHealth);
                p.health = p.maxHealth;
                rb2 = p.mainPlayer.GetComponent<Rigidbody2D>();
                rb2.velocity = new Vector2(0, 0);
                p.mainPlayer.transform.localPosition = p.spawnPoint.transform.localPosition;
                GetComponent<BoxCollider2D>().enabled = false;
            }
            p.healthBar.SetHealth(p.health);
            GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(1f);
            GetComponent<BoxCollider2D>().enabled = true;
        }

        if (collision.gameObject.tag == "enemyBullet")
        {
            p.health--;
            Destroy(collision.gameObject);
            if (p.health <= 0)
            {
                p.healthBar.SetHealth(p.maxHealth);
                p.health = p.maxHealth;
                rb2 = p.mainPlayer.GetComponent<Rigidbody2D>();
                rb2.velocity = new Vector2(0, 0);
                p.mainPlayer.transform.localPosition = p.spawnPoint.transform.localPosition;
            }
            p.healthBar.SetHealth(p.health);
            GetComponent<BoxCollider2D>().enabled = false;
            yield return new WaitForSeconds(1f);
            GetComponent<BoxCollider2D>().enabled = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "OutOfBounds")
        {
            rb2 = p.mainPlayer.GetComponent<Rigidbody2D>();
            rb2.velocity = new Vector2(0, 0);
            p.mainPlayer.transform.localPosition = p.spawnPoint.transform.localPosition;
            p.healthBar.SetHealth(p.maxHealth);
            p.health = p.maxHealth;
        }
    }
}

  

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //if (collision.tag == "OutOfBounds")
    //{
    //rb2 = p.mainPlayer.GetComponent<Rigidbody2D>();
    //rb2.velocity = new Vector2(0, 0);
    //p.mainPlayer.transform.localPosition = p.spawnPoint.transform.localPosition;
    //p.healthBar.SetHealth(p.maxHealth);
    //p.health = p.maxHealth;
    //}
    //}
