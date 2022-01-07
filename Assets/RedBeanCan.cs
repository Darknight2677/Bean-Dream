using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBeanCan : MonoBehaviour
{
    public PlayerMovement p;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "RedBeanCan")
        {
            p.health = p.maxHealth;
            p.healthBar.SetHealth(p.maxHealth);
            Destroy(collision.gameObject);
        }
    }
}
