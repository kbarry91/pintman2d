using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectController : MonoBehaviour
{

    public string[] unlockedLevels;

    // Levels that are locked
    public GameObject[] levelsLocked;
    public bool[] levelReached;

    // Value of position of lock
    public int positionSelector;
    public float distanceUnderBlock;

    public string[] levelName;
    public float moveSpeed;
    private bool isPressed;
    public bool isTouchScreen;

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

        // Set player position to current level.
        positionSelector = PlayerPrefs.GetInt("PlayerLevelSelectPosition");
        transform.position = levelsLocked[positionSelector].transform.position + new Vector3(0, distanceUnderBlock, 0);
    }
    private void Update()
    {
        if (!isPressed)
        {
            // If moving right.
            if (Input.GetAxis("Horizontal") > 0.25f)
            {
                positionSelector += 1;
                isPressed = true;
            }
            // If moving left.
            if (Input.GetAxis("Horizontal") < -0.25f)
            {
                positionSelector -= 1;
                isPressed = true;
            }
            // If trying to move futher than possible.
            if (positionSelector >= unlockedLevels.Length)
            {
                positionSelector = unlockedLevels.Length - 1;
                isPressed = true;
            }
            if (positionSelector < 0)
            {
                positionSelector = 0;
            }
        }
        if (isPressed)
        {
            // If input is less not a pressable value.
            if (Input.GetAxis("Horizontal") < 0.25f && Input.GetAxis("Horizontal") > -0.25f)
            {
                isPressed = false;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, levelsLocked[positionSelector].transform.position + new Vector3(0, distanceUnderBlock, 0), moveSpeed * Time.deltaTime);

        if (Input.GetButtonDown("Fire1") || Input.GetButtonDown("Jump"))
        {
            // If level at position is unlocked.
            if (levelReached[positionSelector] && !isTouchScreen)
            {
                // Set Positon player is at, keeps player in correct positio entering select menu.
                PlayerPrefs.SetInt("PlayerLevelSelectPosition", positionSelector);

                // load that level.
                SceneManager.LoadScene(levelName[positionSelector]);

            }
        }
    }
}
