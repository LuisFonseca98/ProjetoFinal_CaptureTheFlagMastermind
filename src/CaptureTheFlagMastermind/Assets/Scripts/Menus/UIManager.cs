using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIManager : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject selectPlanetsMenu;
    public GameObject selectLevelsMenu;
    public GameObject selectOptionsMenu;
    public GameObject selectAboutMenu;
    public GameObject selectLevelsPlanetUrdak;
    public GameObject selectLevelsPlanetXanax;
    public GameObject spaceShip;


    public void ShowSelectPlanetsMenu()
    {
        HideAllMenus();
        spaceShip.SetActive(false);
        selectPlanetsMenu.SetActive(true);

    }

    public void ShowSelectLevelsMenu()
    {
        HideAllMenus();
        selectLevelsMenu.SetActive(true);
    }

    public void ShowAboutMenu()
    {
        HideAllMenus();
        selectAboutMenu.SetActive(true);
    }

    public void ShowOptionsMenu()
    {
        HideAllMenus();
        selectOptionsMenu.SetActive(true);
    }
    
    public void ShowLevelsPlanetUrdak()
    {
        selectLevelsPlanetUrdak.SetActive(true);
        selectLevelsPlanetXanax.SetActive(false);
    }

    public void ShowLevelsPlanetXanax()
    {
        selectLevelsPlanetUrdak.SetActive(false);
        selectLevelsPlanetXanax.SetActive(true);
    }

    public void ShowGame()
    {
        SceneManager.LoadScene("Level_1_1");
    }

    
    public void HideMainMenu() {
        mainMenu.SetActive(false);
    }

    public void HideOptionsMenu()
    {
        HideAllMenus();
        mainMenu.SetActive(true);
    }

    public void HideAboutMenu()
    {
        HideAllMenus();
        mainMenu.SetActive(true);
    }

    public void HideSelectPlanetsMenu()
    {
        HideAllMenus();
        selectPlanetsMenu.SetActive(false);
        mainMenu.SetActive(true);
        spaceShip.SetActive(true);

    }


    public void HideAllMenus()
    {
        mainMenu.SetActive(false);
        selectPlanetsMenu.SetActive(false);
        selectLevelsMenu.SetActive(false);
        selectAboutMenu.SetActive(false);
        selectOptionsMenu.SetActive(false);
        selectLevelsPlanetUrdak.SetActive(false);
        selectLevelsPlanetXanax.SetActive(false);
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
