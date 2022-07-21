using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MenusManager
{
    [Header("Different Gameobjects ")]
    public GameObject endGameScreen;
    public GameObject playerUI;
    public GameObject unitSelectionSystem;

    void Start()
    {
        ActiveGameOverMenu();
    }


    public void ActiveGameOverMenu()
    {
        Time.timeScale = 0f;
        endGameScreen.SetActive(true);
        playerUI.SetActive(false);
        unitSelectionSystem.SetActive(false);
    }


}
