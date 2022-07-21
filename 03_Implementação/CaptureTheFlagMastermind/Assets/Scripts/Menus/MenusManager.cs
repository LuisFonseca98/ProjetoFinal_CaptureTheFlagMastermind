using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenusManager: MonoBehaviour
{

    public void BackToMainMenu()
    {
        Time.timeScale = 1f;
        AudioManager.instance.MainMenuSound();
        Debug.Log("Main Menu is back!");
        SceneManager.LoadScene("Menus");

    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        AudioManager.instance.MainMenuSound();
        Debug.Log("Restart Level pls!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void QuitGame()
    {
        Debug.Log("Game closed!");
        Application.Quit();
    }

    
}
