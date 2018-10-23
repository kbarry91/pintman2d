using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {
    public float moveSpeed;
    public bool moveRight;
    Rigidbody2D rigid2D;

    // wall variables
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask whatIsWall;
    private bool contactWall;

    // edge variables
    private bool notAtEdge;
    public Transform edgeCheck;

    // Use this for initialization
    void Start () {
        rigid2D = GetComponent<Rigidbody2D>();
    }
	
	// Update is called once per frame
	void Update () {

        contactWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, whatIsWall);

        notAtEdge = Physics2D.OverlapCircle(edgeCheck.position, wallCheckRadius, whatIsWall);

        if (contactWall || !notAtEdge)
        {
            moveRight = !moveRight;
        }
        if (moveRight)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            rigid2D.velocity = new Vector2(moveSpeed, rigid2D.velocity.y);
        }
        else
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
            rigid2D.velocity = new Vector2(-moveSpeed, rigid2D.velocity.y);

        }
        Debug.Log("Rigid vel:" + rigid2D.velocity);

       
    }
}
