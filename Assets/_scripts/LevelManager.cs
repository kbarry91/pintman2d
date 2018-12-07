using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Level manager handles various aspects level gameplay.
public class LevelManager : MonoBehaviour
{

    /// <summary>
    /// The current checkpoint.
    /// </summary>
    public GameObject currentCheckpoint;

    public GameObject deathParticle;
    public GameObject respawnParticle;

    public float respawnDelay;
    public int deathPenalty;
    private float gravityStore;

    public HealthController healthController;
    private new CameraController camera;

    // The player.
    private PlayerController player;

    /// <summary>
    /// Start this instance.
    /// </summary>
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        camera = FindObjectOfType<CameraController>();
        healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*
     * Respawn the player.
	*/
    public void RespawnPlayer()
    {
        StartCoroutine("RespawnPlayerCo");
    }

    /// <summary>
    /// RespawnPlayerCo adds a delay to the player respawn
    /// </summary>
    public IEnumerator RespawnPlayerCo()
    {
        Debug.Log("DEBUG : Player Respawn");

        // Instantiate death particle where player died.
        Instantiate(deathParticle, player.transform.position, player.transform.rotation);

        // Disable the player while respawning.
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

        // Reset player position.
        player.transform.position = currentCheckpoint.transform.position;
        player.KickBackCounter = 0;

        // Re enable player.
        player.enabled = true;
        player.GetComponent<Renderer>().enabled = true;

        // Restore players health.
        healthController.RestoreHealth();
        healthController.isAlive = true;

        camera.isFollowing = true;

        // Instantiate respawn particle where player respawns
        Instantiate(respawnParticle, currentCheckpoint.transform.position, currentCheckpoint.transform.rotation);
    }
}
