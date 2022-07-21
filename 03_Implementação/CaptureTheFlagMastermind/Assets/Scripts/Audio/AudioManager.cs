using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class AudioManager : MonoBehaviour
{

    //Singleton
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;

    // the different audio sources
    [SerializeField] AudioSource mainMenuSource;
    [SerializeField] AudioSource clickAudioSource;
    [SerializeField] AudioSource gameoverSource;
    [SerializeField] AudioSource victorySource;
    [SerializeField] AudioSource explosionAudioSource;
    [SerializeField] AudioSource damageAudioSource;
    [SerializeField] AudioSource mouseOverSource;
    [SerializeField] AudioSource clickButtonSource;

    //audio clips 
    [SerializeField] List<AudioClip> clickAudio = new List<AudioClip>();
    [SerializeField] AudioClip mainMenuSound;
    [SerializeField] AudioClip damageSound;
    [SerializeField] AudioClip victorySound;
    [SerializeField] AudioClip gameOverSound;
    [SerializeField] AudioClip mouseOverSound;
    [SerializeField] AudioClip clickButtonSound;
    [SerializeField] AudioClip explosionSound;



    public const string MUSIC_KEY = "Music";
    public const string SFX_KEY = "SFX";

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

    public void GenerateRandomAudioClip()
    {
        clickAudioSource.clip = clickAudio[Random.Range(0, clickAudio.Count)];
        clickAudioSource.PlayOneShot(clickAudioSource.clip);
    }


    public void DamageSound()
    {
        damageAudioSource.PlayOneShot(damageSound);
    }

    public void ExplosionSound()
    {
     explosionAudioSource.PlayOneShot(explosionSound);
    }

    public void VictorySound()
    {
        victorySource.PlayOneShot(victorySound);
    }

    public void GameOverSound()
    {
        gameoverSource.PlayOneShot(gameOverSound);
    }

    public void MainMenuSound()
    {
        mainMenuSource.PlayOneShot(mainMenuSound);
    }

    public void StopMainMenuSound()
    {
        mainMenuSource.Stop();
    }

    public void StopExplosionSound()
    {
        explosionAudioSource.Stop();
    }

    public void StopDamageSound()
    {
        damageAudioSource.Stop();
    }

    public void PlayMouseOverSound()
    {
        mouseOverSource.Play();
    }

    public void PlayClickSound()
    {
        clickButtonSource.Play();
    }



}
