using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// HealthController controls player health a UI health displays.
public class HealthController : MonoBehaviour
{

    public static int playerHealth;
    public int maxPlayerHealth;
    public Slider healthBar;
    public bool isAlive;

    private LevelManager levelManager;
    private TimeController timeController;
    private LifeController lifeController;

    // Use this for initialization
    void Start()
    {
        // text = GetComponent<Text>();
        //(replaced with slider)
        healthBar = GetComponent<Slider>();

        // Set Health to saved health value.
        playerHealth = PlayerPrefs.GetInt("CurrentPlayerHealth");

        // Get LevelManger
        timeController = FindObjectOfType<TimeController>();
        levelManager = FindObjectOfType<LevelManager>();
        lifeController = FindObjectOfType<LifeController>();
        isAlive = true;

    }

    // Update is called once per frame
    void Update()
    {
        // if health is 0 respawn.
        if (playerHealth <= 0 && isAlive)
        {
            playerHealth = 0;
            levelManager.RespawnPlayer();
            lifeController.LoseLife();
            isAlive = false;
            timeController.ResetTime();
        }

        if (playerHealth > maxPlayerHealth)
        {
            playerHealth = maxPlayerHealth;
        }
        // Update UI
        // text.text = "" + playerHealth;
        // Replaced with slider
        healthBar.value = playerHealth;
    }

    // Decrease enemies health
    public static void DamagePlayer(int damage)
    {
        playerHealth -= damage;
        // Save health value.
        PlayerPrefs.SetInt("CurrentPlayerHealth", playerHealth);
    }

    // Restores players health to max capacity.
    public void RestoreHealth()
    {
        playerHealth = PlayerPrefs.GetInt("MaxPlayerHealth");
        PlayerPrefs.SetInt("CurrentPlayerHealth", playerHealth);

    }

    // Instantly kill player.
    public void KillPlayer()
    {
        playerHealth = 0;

    }
}
