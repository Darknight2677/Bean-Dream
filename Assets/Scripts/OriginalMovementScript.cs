using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OriginalMovementScript : MonoBehaviour
{
    bool grounded = false;
    Rigidbody2D rb2;
    SpriteRenderer sr;
    Animator a;

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
        a.SetFloat("yVelocity", rb2.velocity.y);
        a.SetBool("Grounded", grounded);

        float horizValue = Input.GetAxis("Horizontal");

        if(horizValue == 0)
        {
            a.SetBool("Moving", false);
        }

        if (horizValue > 0)
        {
            a.SetBool("Moving", true);
        }

        if (horizValue < 0)
        {
            a.SetBool("Moving", true);
        }

        

        rb2.velocity = new Vector2(horizValue * 2, rb2.velocity.y);

        if (horizValue > 0)
        {
            sr.flipX = false;
        }

        if (horizValue < 0)
        {
            sr.flipX = true;
        }

        grounded = Physics2D.BoxCast(transform.position, new Vector2(0.1f, 0.1f), 0, Vector2.down, 1, LayerMask.GetMask("Ground"));
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb2.velocity = new Vector2(rb2.velocity.x, 6);
        }
    }
}
