using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    //Singleton
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;
    public const string MUSIC_KEY = "Music";
    public const string SFX_KEY = "SFXVolume";


    private void Awake()
    {
        if(instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }


    void LoadVolume()
    {
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, 1f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, 1f);

        mixer.SetFloat(SoundManager.MIXER_MUSIC,Mathf.Log10(musicVolume) * 20);
        mixer.SetFloat(SoundManager.MIXER_SFX, Mathf.Log10(sfxVolume) * 20);
    }
}
