using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public string beginLevel;
    public string selectLevel;
    public int currentLives;

    // New Game
    public void NewGame()
    {
        // Load first level
        SceneManager.LoadScene(beginLevel);

        // Set Initial lives for player
        PlayerPrefs.SetInt("PlayerLives", currentLives);
    }
    // Select Level
    public void SelectLevel()
    {
        // Reset lives for player
        PlayerPrefs.SetInt("PlayerLives", currentLives);
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
