using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SelectLevelsMenu : MonoBehaviour
{

    //para mudar entre as diferentes cenas:
    //1º usar o package "UnityEngine.SceneManagement"
    //2º Usar SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1)
    // SceneManager.LoadScene(SceneManager.LoadScene(1))
    // SceneManager.LoadScene(SceneManager.LoadScene("Level 1-1"))

    public void SelectLevel1_1()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    public void SelectLevel1_2()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);

    }

    public void SelectLevel1_3()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);

    }


    /*public static int getIndexScene()
    {
        return indexScene;
    }
    */
}
