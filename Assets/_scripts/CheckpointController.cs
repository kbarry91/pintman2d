using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Checkpoint controller.
/// </summary>
public class CheckpointController : MonoBehaviour {
	public LevelManager levelManager;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		levelManager = FindObjectOfType<LevelManager> ();
	}

	
	// Update is called once per frame
	void Update () {
		
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	void OnTriggerEnter2D(Collider2D collide){
		if (collide.name == "Player") {
			levelManager.currentCheckpoint = gameObject;
			Debug.Log ("DEBUG : CheckPoint " + transform.position);
		}
	}
}
