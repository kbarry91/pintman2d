using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Level manager.
/// </summary>
public class LevelManager : MonoBehaviour {
	
	/// <summary>
	/// The current checkpoint.
	/// </summary>
	public GameObject currentCheckpoint;
  
    public GameObject deathParticle;
    public GameObject respawnParticle;
    public float respawnDelay;
    public int deathPenalty;
    /// <summary>
	/// The player.
	/// </summary>
	private PlayerController player;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		player = FindObjectOfType<PlayerController> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    
	/*
	*/
	public void RespawnPlayer(){
        StartCoroutine("RespawnPlayerCo");
    }
    /// <summary>
    /// RespawnPlayerCo adds a delay to the player respawn
    /// </summary>
    /// <returns></returns>
    public IEnumerator RespawnPlayerCo()
    {
        Debug.Log("DEBUG : Player Respawn");

        // Instantiate death particle where player died
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        // Disable the player while respawning
        player.enabled = false;
        player.GetComponent<Renderer>().enabled = false;

        // stop player when respawn
        player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Deduct points from score
        ScoreManager.AddPoints(-deathPenalty);

        yield return new WaitForSeconds(respawnDelay);
        player.transform.position = currentCheckpoint.transform.position;

        // Re enable player
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;
        // Instantiate respawn particle where player respawns
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

    }
}
