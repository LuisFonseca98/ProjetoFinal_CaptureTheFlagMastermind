using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public abstract class MenusManager: MonoBehaviour
{
    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Menus");
    }

    public void RestartLevel()
    {
        SceneManager.GetActiveScene();
    }

    public void QuitGame()
    {
        Debug.Log("Game closed!");
        Application.Quit();
    }

    
}
