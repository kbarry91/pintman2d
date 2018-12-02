﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{

    public static int playerHealth;
    public int maxPlayerHealth;
    Text text;
    public bool isAlive;
    private LevelManager levelManager;

    private LifeController lifeController;
    // Use this for initialization
    void Start()
    {
        text = GetComponent<Text>();

        // Set Health to max
        //playerHealth = maxPlayerHealth;
        playerHealth = PlayerPrefs.GetInt("CurrentPlayerHealth");
        // Get LevelManger
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
        }

        // update ui
        text.text = "" + playerHealth;
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
}
