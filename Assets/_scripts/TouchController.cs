using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchController : MonoBehaviour {

    private PlayerController player;

	// Use this for initialization
	void Start () {
        player = FindObjectOfType<PlayerController>();

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
    }
}
