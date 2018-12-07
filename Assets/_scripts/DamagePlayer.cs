using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controller for player damage.
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
            // Decrease players health.
            HealthController.DamagePlayer(damage);

            // Play audio source.
            collide.GetComponent<AudioSource>().Play();

            // knockback player. 
            var player = collide.GetComponent<PlayerController>();
            if (gameObject.GetComponent<PickUpHealth>())
            {
                print(collide.name + " Collided with " + gameObject);

                return;
            }
            else
            {
                player.KickBackCounter = player.kickBackLength;

            }

            // determine direction to kick player
            if (collide.transform.position.x < transform.position.x)
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
