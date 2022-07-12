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


    // Update is called once per frame
    void Update()
    {
        ActiveVictoryScreen();
    }

    public void ActiveVictoryScreen()
    {
        AudioManager.instance.MainMenuSound();
        victoryScreen.SetActive(true);
        playerUI.SetActive(false);
        unitSelectionSystem.SetActive(false);
    }

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

}
