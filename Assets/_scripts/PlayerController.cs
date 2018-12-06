using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 
    Rigidbody2D rigid2D;

    //player variables
    public float moveSpeed = 5;
    //public float maxSpeed = 2f;
    public float jumpHeight = 18;
    private float moveVelocity;

    // grounded variables
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    // Animator
    private Animator anim;
    private bool doubleJumped;

    // Player kickBack
    public float kickBack;
    public float kickBackLength;
    public float KickBackCounter;
    public bool kickFromRight;

    // variables for firing weapon
    public Transform firePoint;
    public GameObject weaponStar;

    public float shootDelay;
    private float shootDelayCounter;

    // Use this for initialization
    void Start()
    {
        // assign component to script
        anim = GetComponent<Animator>();
        rigid2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        if (grounded)
            doubleJumped = false;

        // set bool for jumping animation
        anim.SetBool("Grounded", grounded);

        // determine if device is computer or mobile
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        if (Input.GetButtonDown("Jump") && grounded)
        {
            Jump();
            //
        }
        if (Input.GetButtonDown("Jump") && !grounded && !doubleJumped)
        {
           
            Jump();
            doubleJumped = true;
            //
        }
        Move(Input.GetAxisRaw("Horizontal"));
#endif
        /*
           // flip player
           if (rigid2D.velocity.x > 0)
               transform.localScale = new Vector3(1f, 1f, 1f);
           else if (rigid2D.velocity.x < 0)
              transform.localScale = new Vector3(-1f, 1f, 1f);
   */
        // flip player
        //  Debug.Log("rigid2D.velocity.======"+ rigid2D.velocity.x);
        // Restrict movement after kickBack
        if (KickBackCounter <= 0)
        {
            //Vector2 moveVel = rigid2D.velocity;
            //moveVel.x = this.moveVelocity;
            // rigid2D.velocity = moveVel;
            rigid2D.velocity = new Vector2(moveVelocity, rigid2D.velocity.y);
        }
        else
        {
            if (kickFromRight)
            {
                rigid2D.velocity = new Vector2(-kickBack, kickBack);
            }
            else
            {
                rigid2D.velocity = new Vector2(kickBack, kickBack);
            }
            KickBackCounter -= Time.deltaTime;
        }
        // Set animation speed
        anim.SetFloat("Speed", Mathf.Abs(rigid2D.velocity.x));

        if (rigid2D.velocity.x > 0)
            transform.localScale = new Vector2(1f, 1f);
        else if (rigid2D.velocity.x < 0)
            transform.localScale = new Vector2(-1f, 1f);

        // determine if device is computer or mobile
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        // instansiate weapon object when player shoots, Sets a delay to next shot
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            shootDelayCounter = shootDelay;
          //  Instantiate(weaponStar, firePoint.position, firePoint.rotation);
        }
        if (Input.GetButton("Fire1"))
        {
            shootDelayCounter -= Time.deltaTime;
            if (shootDelayCounter <= 0)
            {
                shootDelayCounter = shootDelay;
                Shoot();
            }
        }
        
#endif

    }

    void FixedUpdate()
    {
        this.grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }

    // Move player
    public void Move(float moveInput)

    {
        moveVelocity = moveInput * moveSpeed;


        // Vector2 moveVel = rigid2D.velocity;
        // moveVel.x = horizontalInput * moveSpeed;
        //  rigid2D.velocity = moveVel;
    }

    // Jump 

    public void Jump()
    {
        // rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpHeight);
        //

        if (grounded)
        {
            // doubleJumped = false;
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpHeight);
            //
        }
        if (!grounded && !doubleJumped)
        {
            rigid2D.velocity = new Vector2(rigid2D.velocity.x, jumpHeight);
            doubleJumped = true;

            //
        }

    }
    public void Shoot()
    {
        Instantiate(weaponStar, firePoint.position, firePoint.rotation);

    }

}