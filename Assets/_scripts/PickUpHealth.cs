using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpHealth : MonoBehaviour {

    public int healthToAdd;
    public AudioSource pickUpSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // If collision is not player return
        if (collision.GetComponent<PlayerController>() == null)
        {
            return;
        }

        HealthController.DamagePlayer(-healthToAdd);
        pickUpSound.Play();

        // Destroy health pick up
        Destroy(gameObject);
    }
}
