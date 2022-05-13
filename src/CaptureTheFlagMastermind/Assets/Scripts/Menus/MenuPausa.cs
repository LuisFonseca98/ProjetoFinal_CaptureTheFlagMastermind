using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : MenusManager
{
    public static bool pauseMode = false;

    public GameObject pauseMenuUI;

    public GameObject unitSelectionSystem;


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

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        unitSelectionSystem.SetActive(true);
        Time.timeScale = 1f;
        pauseMode = false;
    }

    public void PauseMenu()
    {
        pauseMenuUI.SetActive(true);
        unitSelectionSystem.SetActive(false);
        Time.timeScale = 0f;
        pauseMode = true;
    }

}
