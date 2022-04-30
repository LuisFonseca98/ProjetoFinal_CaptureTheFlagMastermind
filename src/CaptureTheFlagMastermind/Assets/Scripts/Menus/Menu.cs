using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{

    public bool ativo;


    public void activar(){
        ativo = true;
    }

    public void desativar(){
        ativo = false;
    }


}
