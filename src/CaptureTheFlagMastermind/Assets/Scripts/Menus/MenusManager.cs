using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenusManager: MonoBehaviour
{

    private float  timeScale = 1f;
    public void BackToMainMenu()
    {
        Debug.Log("Main Menu is back!");
        Time.timeScale = timeScale;
        SceneManager.LoadScene("Menus");

    }

    public void RestartLevel()
    {
        Debug.Log("Restart Level pls!");
        Time.timeScale = timeScale;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }

    public void QuitGame()
    {
        Debug.Log("Game closed!");
        Application.Quit();
    }

    
}
