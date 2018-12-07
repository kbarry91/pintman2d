using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string beginLevel;
    public string selectLevel;
    public int currentLives;
    public int currentHealth;

    public string level1Tag;

    // New Game
    public void NewGame()
    {

        // Set Initial preferences for player
        PlayerPrefs.SetInt("CurrentPlayerLives", currentLives);
        PlayerPrefs.SetInt("CurrentPlayerScore", 0);
        PlayerPrefs.SetInt("CurrentPlayerHealth", currentHealth);
        PlayerPrefs.SetInt("MaxPlayerHealth", currentHealth);

        // Start new game at level 1 and menu position 0

        PlayerPrefs.SetInt(level1Tag, 1);
        PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);

        // Load first level
        SceneManager.LoadScene(beginLevel);
    }

    // Select Level
    public void SelectLevel()
    {
        // Set Initial preferences for player
        PlayerPrefs.SetInt("CurrentPlayerLives", currentLives);
        PlayerPrefs.SetInt("CurrentPlayerScore", 0);
        PlayerPrefs.SetInt("CurrentPlayerHealth", currentHealth);
        PlayerPrefs.SetInt("MaxPlayerHealth", currentHealth);

        PlayerPrefs.SetInt(level1Tag, 1);

        // Check if PlayerLevelSelectPosition does not have value set to 0
        if (!PlayerPrefs.HasKey("PlayerLevelSelectPosition"))
        {
            PlayerPrefs.SetInt("PlayerLevelSelectPosition", 0);
        }

        // Load first level
        SceneManager.LoadScene(selectLevel);
    }
    // exit Game
    public void ExitGame()
    {
        // Quit Game
        Application.Quit();
        Debug.Log("User has exited game");
    }

}
