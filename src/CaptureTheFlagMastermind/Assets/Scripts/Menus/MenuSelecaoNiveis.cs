using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSelecaoNiveis : Menu
{

    //para mudar entre as diferentes cenas:
    //1º usar o package "UnityEngine.SceneManagement"
    //2º Usar SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1)
    // SceneManager.LoadScene(SceneManager.LoadScene(1))
    // SceneManager.LoadScene(SceneManager.LoadScene("Level 1-1"))
    private string nomeNivel;


    public void selecionarNivel()
    {
        SceneManager.LoadScene("LoadingScreen");
    }
}
