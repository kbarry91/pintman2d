using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpLife : MonoBehaviour {

    private LifeController lifeController;

	// Use this for initialization
	void Start () {
        lifeController = FindObjectOfType<LifeController>();
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.name == "Player")
        {
            lifeController.AddLife();
            Destroy(gameObject);
        }
    }
}
