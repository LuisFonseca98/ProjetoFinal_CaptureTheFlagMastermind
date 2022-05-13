using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuOpcoes : MonoBehaviour
{

    public TMPro.TMP_Dropdown dropDownResolutions;
    Resolution[] resolutions;


    void Start()
    {
        resolutions = Screen.resolutions;

        dropDownResolutions.ClearOptions();

        List<string> options = new List<string>();


        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width &&
                resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        dropDownResolutions.AddOptions(options);
        dropDownResolutions.value = currentResolutionIndex;
        dropDownResolutions.RefreshShownValue();
    }

    public void ShowDifferentResolutions(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
        
    }

    public void ChangeGraphics(int graphicsIndex)
    {
        QualitySettings.SetQualityLevel(graphicsIndex);
    }

    public void ActivateFullscreen(bool fullscreen)
    {
        Screen.fullScreen = fullscreen;
    }
}
