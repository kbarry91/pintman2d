using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// A controller to manage checkpoints and respawn position.
public class CheckpointController : MonoBehaviour
{
    public LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    // Update is called once per frame.
    void Update()
    {

    }

    // Trigger when Player collides with Checkpoint.
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.name == "Player")
        {
            levelManager.currentCheckpoint = gameObject;
            Debug.Log("DEBUG : CheckPoint " + transform.position);
        }
    }
}
