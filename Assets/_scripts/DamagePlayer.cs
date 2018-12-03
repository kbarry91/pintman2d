using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePlayer : MonoBehaviour
{

    public int damage;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.name == "Player")
        {
            HealthController.DamagePlayer(damage);
            collide.GetComponent<AudioSource>().Play();

            // knockback player 
            var player = collide.GetComponent<PlayerController>();
            player.KickBackCounter = player.kickBackLength;

            // determine direction to kick player
            if(collide.transform.position.x < transform.position.x)
            {
                player.kickFromRight = true;
            }
            else
            {
                player.kickFromRight = false;
            }
        }
    }
}
