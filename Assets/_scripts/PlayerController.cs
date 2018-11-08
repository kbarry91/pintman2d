using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// 
	Rigidbody2D rigid2D;

	//player variables
	public float moveSpeed = 5;
	//public float maxSpeed = 2f;
	public float jumpHeight = 18;
    private readonly float moveVelocity;
	
    // grounded variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

    // variables for firing weapon
    public Transform firePoint;
    public GameObject weaponStar;

	// Use this for initialization
	void Start () {
		rigid2D = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

        Move(Input.GetAxis("Horizontal"));
        if (grounded)
            doubleJumped = false;

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
            //
        }
        if (Input.GetKeyDown(KeyCode.Space) && !grounded && !doubleJumped)
        {
            doubleJumped = true;
            Jump();
            //
        }
        /*
           // flip player
           if (rigid2D.velocity.x > 0)
               transform.localScale = new Vector3(1f, 1f, 1f);
           else if (rigid2D.velocity.x < 0)
              transform.localScale = new Vector3(-1f, 1f, 1f);
   */
        // flip player
        Debug.Log("rigid2D.velocity.======"+ rigid2D.velocity.x);
        if (rigid2D.velocity.x > 0)
            transform.localScale = new Vector2(1f, 1f);
        else if (rigid2D.velocity.x < 0)
            transform.localScale = new Vector2(-1f, 1f);
        
        // instansiate weapon object when player shoots
        if (Input.GetKeyDown(KeyCode.V))
        {
            Instantiate(weaponStar, firePoint.position, firePoint.rotation);
        }
    }

    void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

	}

	// Move player
	public void Move (float horizontalInput) {
		Vector2 moveVel = rigid2D.velocity;
		moveVel.x = horizontalInput * moveSpeed;
		rigid2D.velocity = moveVel;
	}

	// Jump 

	public void Jump () {
		rigid2D.velocity = new Vector2 (moveSpeed, jumpHeight);
		//

	}

}