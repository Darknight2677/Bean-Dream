using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knockback : MonoBehaviour
{
    Rigidbody2D rb2;
    public PlayerMovement m;
    // Start is called before the first frame update
    void Start()
    {
        m = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            //if (m == GetComponent<PlayerMovement>().dashOK == false)
            //{
                //TakeDamage(12);
            //}

            rb2.velocity = Vector2.zero;
            rb2.AddForce(new Vector2(-(collision.transform.position - transform.position).x * 5, 6), ForceMode2D.Impulse);
            //m.RegSpeed = 0;
            //m.dashspeed = 0;
            //m.MovementSpeed = 0;
            StartCoroutine("ResetMoveSpeed");
        }
    }

    // IEnumerator ResetMoveSpeed()
    //{
        //yield return new WaitForSeconds(.75f);
        //m.RegSpeed = 4;
        //m.dashspeed = 8;
        //m.MovementSpeed = 4;
        //m.rb.velocity
    //}

}
