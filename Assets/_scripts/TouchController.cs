using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    private PlayerController player;
    private LevelLoader launchLevel;
    private PauseMenu pauser;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();
        launchLevel = FindObjectOfType<LevelLoader>();
        pauser = FindObjectOfType<PauseMenu>();
	}

    public void LeftArrowButton()
    {
        player.Move(-1);
    }
    public void RightArrowButton()
    {
        player.Move(1);

    }
    public void NotPushedArrowButton()
    {
        player.Move(0);

    }
    public void Shoot()
    {
        player.Shoot();
    }
    public void Jump()
    {
        player.Jump();

        // If player is in next level door and initiates a jump load next level.
        if (launchLevel.playerInDoor)
        {
            launchLevel.LaunchLevel();
        }
    }

    // Pause game using touch
    public void PauseGame()
    {
        pauser.PauseUpdate();
    }

}
