using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	// 
	Rigidbody2D rigid2D;

	//player variables
	public float moveSpeed;
	public float jumpHeight;

	// Use this for initialization
	void Start () {
		rigid2D = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown(KeyCode.Space)){
			rigid2D.velocity = new Vector2(0,jumpHeight);

		}	
	}
}
