using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : Menu

{

    public GameObject spaceShip;

    public void mostrarMenuPrincipal(){
       
    }

    public void mostrarMenuOpcoes(){

    }

    public void mostrarMenuAbout(){

    }

    public void mostrarSelecaoPlanetas(){

    }


    public void esconderMenuPrincipal(){
        spaceShip.SetActive(false);

    }

    public void esconderMenuOpcoes(){

    }

    public void esconderMenuAbout(){

    }

    public void esconderSelecaoNiveis(){
        
    }

    public void fecharJogo()
    {
        Debug.Log("Quit Game!");
        Application.Quit();
    }


    
}
