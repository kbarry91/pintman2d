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

    private float gravityStore;

    private new CameraController camera;
    /// <summary>
	/// The player.
	/// </summary>
	private PlayerController player;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		player = FindObjectOfType<PlayerController> ();
        camera = FindObjectOfType<CameraController>();
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
        camera.isFollowing = false;

        // remove gravity when player dies
       //gravityStore= player.GetComponent<Rigidbody2D>().gravityScale;
        //player.GetComponent<Rigidbody2D>().gravityScale=0f;

        // stop player when respawn
       // player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;

        // Deduct points from score
        ScoreManager.AddPoints(-deathPenalty);

        yield return new WaitForSeconds(respawnDelay);

        //reset player gravity
       // player.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        player.transform.position = currentCheckpoint.transform.position;
       // player.transform.position = new Vector3(currentCheckpoint.transform.position.x, currentCheckpoint.transform.position.y, player.transform.position.z);

        // Re enable player
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;

        camera.isFollowing = true;
        // Instantiate respawn particle where player respawns
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);

    }
}
