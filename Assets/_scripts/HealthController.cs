using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    public static int playerHealth;
    public int maxPlayerHealth;
    //Text text;
    public Slider healthBar;
    public bool isAlive;
    private LevelManager levelManager;
    private TimeController timeController;
    private LifeController lifeController;
    // Use this for initialization
    void Start()
    {
        //text = GetComponent<Text>();
        healthBar = GetComponent<Slider>();
        // Set Health to max
        //playerHealth = maxPlayerHealth;
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
        // if health is 0 respawn
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
        // update ui
        //  text.text = "" + playerHealth;
        healthBar.value = playerHealth;
    }

    // Decrease enemies health
    public static void DamagePlayer(int damage)
    {
        playerHealth -= damage;
        PlayerPrefs.SetInt("CurrentPlayerHealth", playerHealth);
    }

    public void RestoreHealth()
    {
        playerHealth = PlayerPrefs.GetInt("MaxPlayerHealth");
        PlayerPrefs.SetInt("CurrentPlayerHealth", playerHealth);

    }
    public  void KillPlayer()
    {
        playerHealth = 0;
        
    }
}
