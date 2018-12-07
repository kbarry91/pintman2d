using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TouchLevelController : MonoBehaviour
{

    public LevelSelectController levelSelectController;

    // Use this for initialization
    void Start()
    {
        levelSelectController = FindObjectOfType<LevelSelectController>();
        levelSelectController.isTouchScreen = true;
    }

    public void MoveLeft()
    {
        levelSelectController.positionSelector -= 1;
        if (levelSelectController.positionSelector < 0)
        {
            levelSelectController.positionSelector = 0;
        }
    }

    public void MoveRight()
    {
        levelSelectController.positionSelector += 1;

        // if trying to move futher than possible
        if (levelSelectController.positionSelector >= levelSelectController.unlockedLevels.Length)
        {
            levelSelectController.positionSelector = levelSelectController.unlockedLevels.Length - 1;
        }

    }

    public void LoadLevel()
    {
        // Set Positon player is at, keeps player in correct positio entering select menu
        PlayerPrefs.SetInt("PlayerLevelSelectPosition", levelSelectController.positionSelector);
        // load that level
        SceneManager.LoadScene(levelSelectController.levelName[levelSelectController.positionSelector]);

    }
}
