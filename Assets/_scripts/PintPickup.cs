using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PintPickup : MonoBehaviour {

    public int pointsToAdd;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // only allow player pickup coins
        if (other.GetComponent<PlayerController>() == null)
            return;

        ScoreManager.AddPoints(pointsToAdd);

        // remove point object
        Destroy(gameObject);
    }
    
}
