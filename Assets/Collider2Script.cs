using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Collider2Script : MonoBehaviour
{
    Rigidbody2D rb2;
    public PlayerMovement p;
    public Timer t;
    public float AddedTime = 5;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedBeanCan")
        {
            p.health = p.maxHealth;
            p.healthBar.SetHealth(p.maxHealth);
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "BrownBeanCan")
        {
            t.currentTime += AddedTime;
            Destroy(collision.gameObject);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}