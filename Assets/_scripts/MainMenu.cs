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

    // New Game
    public void NewGame()
    {

        // Set Initial preferences for player
        PlayerPrefs.SetInt("CurrentPlayerLives", currentLives);
        PlayerPrefs.SetInt("CurrentPlayerScore", 0);
        PlayerPrefs.SetInt("CurrentPlayerHealth", currentHealth);
        PlayerPrefs.SetInt("MaxPlayerHealth", currentHealth);

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

        // Load first level
        SceneManager.LoadScene(selectLevel);
    }
    // exit Game
    public void ExitGame()
    {
        // Quit Game
        //SceneManager.LoadScene(beginLevel);
        Application.Quit();
        Debug.Log("User has exited game");
    }

}
