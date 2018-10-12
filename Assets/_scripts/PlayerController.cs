using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// 
	Rigidbody2D rigid2D;

	//player variables
	public float moveSpeed = 5;
	public float maxSpeed = 2f;
	public float jumpHeight = 18;

	// grounded variables
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;

	// Use this for initialization
	void Start () {
		rigid2D = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);

		Move (Input.GetAxis ("Horizontal"));
		if (grounded)
			doubleJumped = false;

		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			Jump ();
			//
		}
		if (Input.GetKeyDown (KeyCode.Space) && !grounded && !doubleJumped) {
			doubleJumped = true;
			Jump();
			//
		}
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