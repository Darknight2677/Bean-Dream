using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvanMovementScript : MonoBehaviour
{
    bool grounded = false;
    Rigidbody2D rb2;
    Animator a;
    public GameObject spawnPoint;
    public GameObject mainPlayer;

    public int maxHealth = 3;
    public int health;
    public HealthBar healthBar;

    public Timer timer;

    // Start is called before the first frame update
    void Start()
    {

        rb2 = gameObject.GetComponent<Rigidbody2D>();
        a = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            health--;
            if (health < 1)
            {
                healthBar.SetHealth(maxHealth);
                health = maxHealth;
                rb2 = mainPlayer.GetComponent<Rigidbody2D>();
                rb2.velocity = new Vector2(0, 0);
                mainPlayer.transform.localPosition = spawnPoint.transform.localPosition;
            }
            healthBar.SetHealth(health);
        }

        if (collision.gameObject.tag == "enemyBullet")
        {
            health--;
            Destroy(collision.gameObject);
            if (health < 1)
            {
                healthBar.SetHealth(maxHealth);
                health = maxHealth;
                rb2 = mainPlayer.GetComponent<Rigidbody2D>();
                rb2.velocity = new Vector2(0, 0);
                mainPlayer.transform.localPosition = spawnPoint.transform.localPosition;
            }
            healthBar.SetHealth(health);
        }
    }
}
