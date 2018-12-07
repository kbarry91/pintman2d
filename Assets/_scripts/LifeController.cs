using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeController : MonoBehaviour
{

    // public int initialLives;
    private int lifeCounter;
    private Text lifeText;

    // Overview when game ends
    public GameObject gameOverView;

    // stop player
    public PlayerController player;

    public string mainMenu;
    public float delayContinue;

    // Use this for initialization
    void Start()
    {
        lifeText = GetComponent<Text>();

        // Get PlayerLives
        lifeCounter = PlayerPrefs.GetInt("CurrentPlayerLives");
        player = FindObjectOfType<PlayerController>();

    }

    // Update is called once per frame
    void Update()
    {
        if (lifeCounter == 0)
        {
            gameOverView.SetActive(true);
            player.gameObject.SetActive(false);
        }
        lifeText.text = "x " + lifeCounter;

        // If game over view is active set delay to reload menu.
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
        PlayerPrefs.SetInt("CurrentPlayerLives", lifeCounter);
    }

    // Remove a life
    public void LoseLife()
    {
        lifeCounter--;
        PlayerPrefs.SetInt("CurrentPlayerLives", lifeCounter);
    }
}
