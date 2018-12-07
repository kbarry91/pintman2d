using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController : MonoBehaviour
{
    public float startTime;
    private float timeCounter;
    private Text displayText;
    private PauseMenu pauseGameMenu;

    // stop player
    private HealthController healthController;

    // Use this for initialization
    void Start()
    {
        timeCounter = startTime;

        // attach componet to displayText
        displayText = GetComponent<Text>();
        pauseGameMenu = FindObjectOfType<PauseMenu>();

        healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseGameMenu.isPaused)
        {
            return;
        }
        timeCounter -= Time.deltaTime;

        // Activate Game over screen when time limit reached
        if (timeCounter <= 0)
        {
            //gameOverView.SetActive(true);
            //player.gameObject.SetActive(false);
            healthController.KillPlayer();
        }
        displayText.text = "" + Mathf.Round(timeCounter);
    }

    // reset timeCounter
    public void ResetTime()
    {
        timeCounter = startTime;
    }
}
