using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MenusManager
{
    [Header("Different Gameobjects ")]
    public GameObject victoryScreen;
    public GameObject playerUI;
    public GameObject unitSelectionSystem;

    void Start()
    {
        AudioManager.instance.StopMainMenuSound();
        ActiveVictoryScreen();
    }

    public void ActiveVictoryScreen()
    {
        Time.timeScale = 0f;
        AudioManager.instance.VictorySound();
        victoryScreen.SetActive(true);
        playerUI.SetActive(false);
        unitSelectionSystem.SetActive(false);
    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
