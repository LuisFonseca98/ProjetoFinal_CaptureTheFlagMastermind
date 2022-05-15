using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MenuSelecaoNiveis : MonoBehaviour
{

    //para mudar entre as diferentes cenas:
    //1º usar o package "UnityEngine.SceneManagement"
    //2º Usar SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1)
    // SceneManager.LoadScene(SceneManager.LoadScene(1))
    // SceneManager.LoadScene(SceneManager.LoadScene("Level 1-1"))

    public void SelectLevel(int index)
    {

        if(index == 0)
        {
            SceneManager.LoadScene("Level_1_1");
            Debug.Log("Selecionei o nivel 1-1");
        }else if (index == 1) { 
            SceneManager.LoadScene("Level_1_2");
            Debug.Log("Selecionei o nivel 1-2");
        }

    }
}
