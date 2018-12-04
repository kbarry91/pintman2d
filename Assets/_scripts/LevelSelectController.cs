using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectController : MonoBehaviour
{

    public string[] unlockedLevels;

    public GameObject[] levelsLocked;
    public bool[] levelReached;

    private void Start()
    {
        // Iterate through unlockedLevels
        for (int i = 0; i < unlockedLevels.Length; i++)
        {
            if (PlayerPrefs.GetInt(unlockedLevels[i]) == null)
            {
                levelReached[i] = false;
            }
            else if (PlayerPrefs.GetInt(unlockedLevels[i]) == 0)
            {
                levelReached[i] = false;

            }
            else
            {
                levelReached[i] = true;
            }
            if (levelReached[i])
            {
                levelsLocked[i].SetActive(false);
            }
        }
    }
    private void Update()
    {

    }
}
