using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour {

    public string beginLevel;
    public string selectLevel;

    // New Game
    public void NewGame()
    {
        // Load first level
        SceneManager.LoadScene(beginLevel);
    }
    // Select Level
    public void SelectLevel()
    {
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
