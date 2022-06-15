using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenusManager: MonoBehaviour
{
    public void BackToMainMenu()
    {
        Debug.Log("Main Menu is back bitches!");
        SceneManager.LoadScene("Menus");
        Time.timeScale = 1f;

    }

    public void RestartLevel()
    {
        Debug.Log("Restart Level pls!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        Debug.Log("Game closed!");
        Application.Quit();
    }

    
}
