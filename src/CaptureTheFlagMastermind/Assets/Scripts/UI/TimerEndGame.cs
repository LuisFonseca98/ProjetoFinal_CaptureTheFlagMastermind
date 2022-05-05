using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerEndGame : MonoBehaviour
{
    //variables of the diferent values
    public float timeValue = 300;
    public float reputationValue;
    private bool stopIncreasingReputatio;

    //variables for the timer and reputation text
    public TMP_Text timerText;
    public TMP_Text reputationCounterText;

    //reference to the gameobjects
    public GameObject endGameScreen;
    public GameObject playerUI;

    public AudioSource gameoverAudio;

    private void Start()
    {
        stopIncreasingReputatio = true;
        StartCoroutine(reputationCounterIncreasing());
    }

    //Update is called once per frame
    void Update()
    {
        if (timeValue > 0)
        {
            timeValue -= Time.deltaTime;
        }
        else
        {
            timeValue = 0;
        }

        DisplayTime(timeValue);
    }

    void DisplayTime(float timeToDisplay)
    {
        if (timeToDisplay < 0)
        {

            timeToDisplay = 0;
            Time.timeScale = 0f;
            stopIncreasingReputatio = false;
            endGameScreen.SetActive(true);
            playerUI.SetActive(false);
            gameoverAudio.Play();


        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        reputationCounterText.text = reputationValue.ToString();


    }

    private IEnumerator reputationCounterIncreasing()
    {
        while (stopIncreasingReputatio)
        {
            yield return new WaitForSeconds(1);
            reputationValue += 2;
        }
    }

}