using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeController : MonoBehaviour {

    public int initialLives;
    private int lifeCounter;
    private Text lifeText;

    // Overview when game ends
    public GameObject gameOverView;

    // stop player
    public PlayerController player;

    public string mainMenu;
    public float delayContinue;

	// Use this for initialization
	void Start () {
        lifeText = GetComponent<Text>();
        lifeCounter = initialLives;
        player = FindObjectOfType<PlayerController>();

	}
	
	// Update is called once per frame
	void Update () {
        if (lifeCounter == 0)
        {
            gameOverView.SetActive(true);
            player.gameObject.SetActive(false);
        }
        lifeText.text = "x " + lifeCounter;

        // if game over view is active
        if (gameOverView.activeSelf)
        {
            delayContinue -= Time.deltaTime;
        }
        if (delayContinue < 0)
        {
            SceneManager.LoadScene(mainMenu);
        }
	}

    // Add a life
    public void AddLife()
    {
        lifeCounter++;
    }

    // Remove a life
    public void LoseLife()
    {
        lifeCounter--;
    }
}
