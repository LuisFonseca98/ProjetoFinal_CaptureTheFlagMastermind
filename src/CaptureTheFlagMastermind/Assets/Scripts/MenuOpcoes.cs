using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpcoes : Menu
{

    public TMPro.TMP_Dropdown dropDownResolutions;
    Resolution[] resolucoes;


    private void Start()
    {
        resolucoes = Screen.resolutions;

        dropDownResolutions.ClearOptions();

        List<string> options = new List<string>();


        int currentResolutionIndex = 0;
        for (int i = 0; i < resolucoes.Length; i++)
        {
            string option = resolucoes[i].width + "x" + resolucoes[i].height;
            options.Add(option);

            if (resolucoes[i].width == Screen.currentResolution.width &&
                resolucoes[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        dropDownResolutions.AddOptions(options);
        dropDownResolutions.value = currentResolutionIndex;
        dropDownResolutions.RefreshShownValue();
    }

    public void mostrarDiferentesResolucoes(int indexResolucao){
        Resolution resolucao = resolucoes[indexResolucao];
        Screen.SetResolution(resolucao.width, resolucao.height, Screen.fullScreen);
        
    }

    public void alterarGraficos(int indexGraficos)
    {
        QualitySettings.SetQualityLevel(indexGraficos);
    }

    public void ativarModoTelacheia(bool telaCheia)
    {
        Screen.fullScreen = telaCheia;
    }
}
