using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MenusManager
{
    public static bool pauseMode = false;
    public GameObject pauseMenuUI;
    public GameObject unitSelectionSystem;
    public GameObject optionsMenu;


    void Start()
    {
        //Debug.Log(Screen.width + "x" + Screen.height);

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (pauseMode)
            {
                Resume();
            }
            else
            {
                ShowPauseMenu();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        unitSelectionSystem.SetActive(true);
        Time.timeScale = 1f;
        pauseMode = false;
    }

    public void ShowPauseMenu()
    {
        pauseMenuUI.SetActive(true);
        unitSelectionSystem.SetActive(false);
        Time.timeScale = 0f;
        pauseMode = true;
    }

    public void BackToMainMenuPauseMenu()
    {
        Time.timeScale = 1f;
        AudioManager.instance.MainMenuSound();
        Debug.Log("Main Menu is back!");
        SceneManager.LoadScene("Menus");

    }

    public void ShowOptionsMenu()
    {
        optionsMenu.SetActive(true);    
    }

    public void HideOptionsMenu()
    {
        optionsMenu.SetActive(false);
    }

}
