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
		Debug.Log("DEBUG : Player Respawn");
		player.transform.position = currentCheckpoint.transform.position;
	}

}
