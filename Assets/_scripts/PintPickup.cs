using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintPickup : MonoBehaviour
{
    public int pointsToAdd;
    public AudioSource pintSoundEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Only allow player pickup coins
        if (other.GetComponent<PlayerController>() == null)
            return;

        ScoreManager.AddPoints(pointsToAdd);

        // Play sound clip
        pintSoundEffect.Play();

        // Remove  object
        Destroy(gameObject);
    }

}
