using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverMenu : MenusManager
{
    [Header("Different Gameobjects ")]
    public GameObject endGameScreen;
    public GameObject playerUI;
    public GameObject unitSelectionSystem;


    // Update is called once per frame
    void Update()
    {
        ActiveGameOverMenu();
    }


    public void ActiveGameOverMenu()
    {

        endGameScreen.SetActive(true);
        playerUI.SetActive(false);
        unitSelectionSystem.SetActive(false);
    }


}
