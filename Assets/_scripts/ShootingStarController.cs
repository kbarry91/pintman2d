﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingStarController : MonoBehaviour {

    public float speed;
    Rigidbody2D rigid2DStar;

    public PlayerController player;
    public GameObject enemyDeathEffect;
    public GameObject impactEffect;

    public  int killPoints = 50;
    // Use this for initialization
    void Start () {

        rigid2DStar = GetComponent<Rigidbody2D>();
        player = FindObjectOfType<PlayerController>();

        // If player is aiming left  apply negative velocity
        if(player.transform.localScale.x < 0)
        {
            speed = -speed;
        }
    }
	
	// Update is called once per frame
	void Update () {
        
        // add linear velocity to rigid2DStar
        rigid2DStar.velocity = new Vector2(speed, rigid2DStar.velocity.y);

    }

    // Destroy object on collison
     void OnTriggerEnter2D(Collider2D collidingObject)
        
    {
        // if collider is enemy destroy enemy and apply effect
        if(collidingObject.tag == "Enemy")
        {
            Instantiate(enemyDeathEffect, collidingObject.transform.position, collidingObject.transform.rotation);
            Destroy(collidingObject.gameObject);
            // add game points
            Debug.Log("DEBUG : Destroyed Enemy adding " +killPoints);

            ScoreManager.AddPoints(killPoints);
        }
        // Instantiate impactEffect
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy (gameObject);
        Debug.Log("DEBUG : Destroyed shooting star ,collided with "+ collidingObject.ToString());
    }
}