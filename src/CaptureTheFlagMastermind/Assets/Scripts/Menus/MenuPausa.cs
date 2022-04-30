using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPausa : Menu
{
    public static bool jogoEmModoPausa = false;

    public GameObject PauseMenuUI;

    private string mainMenuScene = "Menus";


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jogoEmModoPausa)
            {
                resume();
            }
            else
            {
                menuPausa();
            }
        }
    }

    public void repetirNivel()
    {
        SceneManager.GetActiveScene();
        Debug.Log(SceneManager.GetActiveScene().name);
    }


    public void resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        jogoEmModoPausa = false;
    }

    public void menuPausa()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        jogoEmModoPausa = true;
    }


    public void carregarMenuPrincipal()
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
