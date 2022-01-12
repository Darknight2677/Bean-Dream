using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    //Movement and Jump Variables
    private Rigidbody2D rb;

    private bool CanMove = true;
    private bool CanJump;
    private bool OnGround;
    private bool OnWall;

    //Noah combined script
    Rigidbody2D rb2;
    Animator a;
    public GameObject spawnPoint;
    public GameObject mainPlayer;

    public int maxHealth = 3;
    public int health;
    public HealthBar healthBar;

    public Timer timer;

    public Text TimerText;

    //Renderer rend;
    //Color c;
    //End of Noah combined script

    [SerializeField] private float MovementSpeed;
    [SerializeField] private float JumpSpeed;
    [SerializeField] private float WallSlideSpeed;

    [SerializeField] private float RayLength;
    [SerializeField] private float RayPositionOffset;

    Vector3 RayPositionCenter;
    Vector3 RayPositionLeft;
    Vector3 RayPositionRight;

    RaycastHit2D[] GroundHitsCenter;
    RaycastHit2D[] GroundHitsLeft;
    RaycastHit2D[] GroundHitsRight;

    RaycastHit2D[][] AllRaycastHits = new RaycastHit2D[3][];

    //Wall Jump Variables
    private bool OnWallRight;
    private bool OnWallLeft;

    Vector3 WallRayPositionLeft;
    Vector3 WallRayPositionRight;

    RaycastHit2D[] WallHitsLeft;
    RaycastHit2D[] WallHitsRight;

    private void Start()
    {
        health = maxHealth;
        a = gameObject.GetComponent<Animator>();
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        //rend = GetComponent<Renderer>();
        //c = rend.material.color;
        rb2 = gameObject.GetComponent<Rigidbody2D>();
        a = gameObject.GetComponent<Animator>();
    }

    private void Update()
    {
        Movement();
        Jump();
        string FText = string.Format("{0:0.0}", timer.currentTime);
        TimerText.text = FText;
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    SceneManager.LoadScene("MainMenuScene");
        //}
        a.SetFloat("yVelocity", rb2.velocity.y);
        a.SetBool("Grounded", OnGround);
        if(OnWallLeft == true)
        {
            a.SetBool("OnWall", true);
            transform.localScale = new Vector3(0.5f, 0.5f, 1);
        }
        if(OnWallRight == true)
        {
            a.SetBool("OnWall", true);
            transform.localScale = new Vector3(-0.5f, 0.5f, 1);
        }
        if (OnWallLeft==false && OnWallRight == false)
        {
            a.SetBool("OnWall", false);
        }
    }

    private void Movement()
    {
        Vector3 local = transform.localScale;
        if (CanMove)
        {
            if (Input.GetAxisRaw("Horizontal") > 0)
            {
                rb.velocity = new Vector2(MovementSpeed * Time.fixedDeltaTime, rb.velocity.y);
                transform.localScale = new Vector3(0.5f, 0.5f, 1);
                a.SetBool("IsWalking", true);
            }
            else if (Input.GetAxisRaw("Horizontal") < 0)
            {
                rb.velocity = new Vector2(-MovementSpeed * Time.fixedDeltaTime, rb.velocity.y);
                transform.localScale = new Vector3(-0.5f, 0.5f, 1);
                a.SetBool("IsWalking", true);
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
                a.SetBool("IsWalking", false);
            }
        }
    }

    private void RaySetup()
    {
        //Ground Check/Standard Jump Ray Setup
        RayPositionCenter = transform.position + new Vector3(0, RayLength * -.5f, 0);
        RayPositionLeft = transform.position + new Vector3(-RayPositionOffset, RayLength * -.5f, 0);
        RayPositionRight = transform.position + new Vector3(RayPositionOffset, RayLength * -.5f, 0);

        GroundHitsCenter = Physics2D.RaycastAll(RayPositionCenter, -Vector2.up, RayLength);
        GroundHitsLeft = Physics2D.RaycastAll(RayPositionLeft, -Vector2.up, RayLength);
        GroundHitsRight = Physics2D.RaycastAll(RayPositionRight, -Vector2.up, RayLength);

        AllRaycastHits[0] = GroundHitsCenter;
        AllRaycastHits[1] = GroundHitsLeft;
        AllRaycastHits[2] = GroundHitsRight;

        OnGround = RayListCheck(AllRaycastHits);
        CanJump = OnGround;

        //Wall Jump/Slide Ray Setup
        WallRayPositionLeft = transform.position + new Vector3(-RayPositionOffset, -.5f, 0);
        WallRayPositionRight = transform.position + new Vector3(RayPositionOffset, -.5f, 0);

        WallHitsLeft = Physics2D.RaycastAll(WallRayPositionLeft, Vector2.left, RayLength);
        WallHitsRight = Physics2D.RaycastAll(WallRayPositionRight, -Vector2.left, RayLength);

        OnWallLeft = RayCheck(WallHitsLeft);
        OnWallRight = RayCheck(WallHitsRight);

        DrawRays();
    }

    private bool RayCheck(RaycastHit2D[] RayHits)
    {
        foreach (RaycastHit2D hit in RayHits)
        {
            if (hit.collider != null)
            {
                if (hit.collider.tag != "PlayerCollider")
                {
                    return true;
                }
            }

        }
        return false;
    }

    private void Jump()
    {
        RaySetup();

        //Ground Jump
        if (Input.GetKey(KeyCode.Space) && CanJump)
        {
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.velocity = new Vector2(rb.velocity.x, JumpSpeed);
        }

        if (!OnGround)
        {
            //Wall Slide
            if (CanMove)
            {
                if (Input.GetAxisRaw("Horizontal") < 0 && OnWallLeft)
                {
                    rb.velocity = new Vector2(rb.velocity.x, -WallSlideSpeed);
                }
                else if (Input.GetAxisRaw("Horizontal") > 0 && OnWallRight)
                {
                    rb.velocity = new Vector2(rb.velocity.x, -WallSlideSpeed);
                }
            }

            //Wall Jump
            if (Input.GetKeyDown(KeyCode.Space) && OnWallLeft)
            {
                rb.velocity = new Vector2(JumpSpeed * 0.5f, JumpSpeed);
                StartCoroutine(WallJumpCoolDown());
            }

            if (Input.GetKeyDown(KeyCode.Space) && OnWallRight)
            {
                rb.velocity = new Vector2(-JumpSpeed * 0.5f, JumpSpeed);
                StartCoroutine(WallJumpCoolDown());
            }
        }
    }

    IEnumerator WallJumpCoolDown()
    {
        CanMove = false;
        yield return new WaitForSeconds(0.25f);
        CanMove = true;
    }

    private bool RayListCheck(RaycastHit2D[][] RayHits)
    {
        foreach (RaycastHit2D[] HitList in RayHits)
        {
            foreach (RaycastHit2D hit in HitList)
            {
                if (hit.collider != null)
                {
                    if (hit.collider.tag != "PlayerCollider")
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }

    private void DrawRays()
    {
        //Ground Rays
        Debug.DrawRay(RayPositionCenter, -Vector2.up * RayLength, Color.red);
        Debug.DrawRay(RayPositionLeft, -Vector2.up * RayLength, Color.red);
        Debug.DrawRay(RayPositionRight, -Vector2.up * RayLength, Color.red);

        //Wall Rays
        Debug.DrawRay(WallRayPositionLeft, Vector2.left * RayLength, Color.blue);
        Debug.DrawRay(WallRayPositionRight, -Vector2.left * RayLength, Color.blue);
    }

   
}

    //Noah combined script


    //private void OnTriggerEnter2D(Collider2D collision)
    //{
        //if (collision.gameObject.tag.Equals("Enemy") && health > 0)
            //StartCoroutine("GetInvulnerable");
    //}

    //IEnumerator GetInvulnerable()
    //{
        //Physics2D.IgnoreLayerCollision(11, 9, true);
        //c.a = 0.5f;
        //rend.material.color = c;
        //yield return new WaitForSeconds(3f);
        //Physics2D.IgnoreLayerCollision(11, 9, false);
        //c.a = 1f;
        //rend.material.color = c;
    //}
    //End of Noah combined script
















































//deez nuts