using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour {
    //  Variable for if player is at end of level door
    private bool playerInDoor;
    //next level
    public string nextLevel;

	// Use this for initialization
	void Start () {
        // Player is not at end of level
        playerInDoor = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetAxisRaw("Vertical")>0 && this.playerInDoor)
        {
            // Load next level
           //Application.LoadLevel(nextLevel);
          SceneManager.LoadScene(nextLevel);
        }
	}
     void OnTriggerEnter2D(Collider2D other)
    {
        // If player is at end of level
        if(other.name== "Player")
        {
            playerInDoor = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // If player is not at end of level
        if (other.name == "Player")
        {
            playerInDoor = false;
        }
    }
}
