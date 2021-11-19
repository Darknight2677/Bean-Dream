using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMove : MonoBehaviour
{
    private float moveSpeed;
    private Rigidbody2D rb2;
    private SpriteRenderer sr;
    public Animator a;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movement * Time.deltaTime * moveSpeed;




        if (Input.GetKeyDown("escape"))
        {
            Debug.Log("kekw");
            Application.Quit();
        }



        //Move Right
        if (Input.GetAxis("Horizontal") > 0)
        {
            sr.flipX = false;
            moveSpeed = 4f;
        }

        //Move Left
        if (Input.GetAxis("Horizontal") < 0)
        {
            sr.flipX = true;
            moveSpeed = 4f;
        }

        a.SetFloat("Moving", Mathf.Abs(Input.GetAxis("Horizontal")));
    }
}
