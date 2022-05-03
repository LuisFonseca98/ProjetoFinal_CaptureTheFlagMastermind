using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerEndGame : MonoBehaviour
{

    [SerializeField] float startTimer;
    public GameObject endGameScreen;
    public GameObject playerUI;
    
    float currentTime;
    
    bool timerStarted = false;

    [SerializeField]
    TMP_Text timerText;
    
    void Start()
    {
        currentTime = startTimer;
        timerStarted = true;
        timerText.text = currentTime.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerStarted)
        {
            currentTime -= Time.deltaTime;
            if (currentTime < 0)
            {
                Debug.Log("Timer reached zero");
                timerStarted = false;
                currentTime = 0;
                Time.timeScale = 0f;
                endGameScreen.SetActive(true);
                playerUI.SetActive(false);
            }

            timerText.text = currentTime.ToString("f1");
        }
    }
}
