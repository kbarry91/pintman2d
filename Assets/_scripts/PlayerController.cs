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

	// Use this for initialization
	void Start () {
		rigid2D = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate () {
		Move (Input.GetAxis ("Horizontal"));
		if (Input.GetKeyDown (KeyCode.Space)) {
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