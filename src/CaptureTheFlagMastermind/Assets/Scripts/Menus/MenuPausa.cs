using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : Menu
{
    public static bool pauseMode = false;

    public GameObject pauseMenuUI;

    private string mainMenuScene = "Menus";
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
                PauseMenu();
            }
        }
    }

    public void RestartLevel()
    {
        SceneManager.GetActiveScene();
        Debug.Log(SceneManager.GetActiveScene().name);
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        pauseMode = false;
    }

    public void PauseMenu()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        pauseMode = true;
    }


    public void LoadMainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game!");
        Application.Quit();
    }
}
