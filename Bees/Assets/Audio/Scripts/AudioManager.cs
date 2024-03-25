using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;
    [SerializeField] AudioMixer masterMixer;
    //[SerializeField] Slider soundSlider;

    public AudioClip menuMusic;
    public AudioClip pollenMusic;
    public AudioClip honeyMusic;
    public AudioClip nurseryMusic;
    public AudioClip hiveMusic;
    public AudioClip defenseMusic;
    public AudioClip hiveBees;
    public AudioClip hiveEnemies;
    public AudioClip itemCollected;
    public AudioClip itemTurnin;
    public AudioClip menuClick;
    public AudioClip ambientNature;
    public AudioClip ambientBees;
    public AudioClip beeTeleport;
    public AudioClip honeyEaten;


    public static AudioManager audioManager;

    private void Start() 
    {
        if(PlayerPrefs.HasKey("MasterVolume"))
        {
            masterMixer.SetFloat("MasterVolume", PlayerPrefs.GetFloat("MasterVolume"));
        }

        if(PlayerPrefs.HasKey("MusicVolume"))
        {
            masterMixer.SetFloat("MusicVolume", PlayerPrefs.GetFloat("MusicVolume"));
        }

        if(PlayerPrefs.HasKey("SFXVolume"))
        {
            masterMixer.SetFloat("SFXVolume", PlayerPrefs.GetFloat("SFXVolume"));
        }

        //SetVolume(PlayerPrefs.GetFloat("SavedMasterVolume", 100));
        //musicSource.clip = menuMusic;
        musicSource.Play();
        audioManager = this;
    }

    public void SetVolume(float _value) 
    {
        if (_value < 1) 
        {
            _value = .001f;
        }

        //RefreshSlider(_value);
        PlayerPrefs.SetFloat("SavedMasterVolume", _value);
        masterMixer.SetFloat("MasterVolume", Mathf.Log10(_value / 100) * 20f);
        PlayerPrefs.SetFloat("SavedMusicVolume", _value);
        masterMixer.SetFloat("MusicVolume", Mathf.Log10(_value / 100) * 20f);
        PlayerPrefs.SetFloat("SavedSFXVolume", _value);
        masterMixer.SetFloat("SFXVolume", Mathf.Log10(_value / 100) * 20f);
    }

    public void ChangeMusic(int id)
    {
        AudioClip selectedMusic;

        // Select the music track based on the provided identifier
        switch(id)
        {
            case 0:
                selectedMusic = menuMusic;
                break;
            case 1:
                selectedMusic = pollenMusic;
                break;
            case 2:
                selectedMusic = honeyMusic;
                break;
            case 3:
               selectedMusic = nurseryMusic;
               break;
           case 4:
               selectedMusic = hiveMusic;
               break;
            case 5:
                selectedMusic = defenseMusic;
                break;
            case 6:
                selectedMusic = menuMusic;
                break;
            default:
                selectedMusic = menuMusic;
            break;
        }

        // Fade out current music and play the selected music
        StartCoroutine(FadeOutAndPlay(selectedMusic, 0.3f));
    }

    private IEnumerator FadeOutAndPlay(AudioClip newClip, float fadeTime)
    {
        // Fade out the current music
        float startVolume = musicSource.volume;

        while (musicSource.volume > 0)
        {
            musicSource.volume -= startVolume * Time.deltaTime / fadeTime;
            yield return null;
        }
            musicSource.Stop();
            musicSource.volume = startVolume;

        // Play the new music
        musicSource.clip = newClip;
        musicSource.Play();
    }



   // public IEnumerator FadeOut(AudioSource audioSource, float FadeTime, int musicID)
   // {
      //  float startVolume = audioSource.volume;

     //   while (audioSource.volume > 0)
      //  {
        //    audioSource.volume -= startVolume * Time.deltaTime / FadeTime;
         //   yield return null;
       // }

      //  audioSource.Stop();
      //  audioSource.volume = startVolume;
       // switch(musicID)
       // {
        //    case 0:
        //        audioSource.clip = menuMusic;
        //        break;
       //     case 1:
        //        audioSource.clip = pollenMusic;
        //        break;
        //    case 2:
       //         audioSource.clip = honeyMusic;
        //        break;
         //   case 3:
          //      audioSource.clip = nurseryMusic;
          //      break;
          //  case 4:
          //      audioSource.clip = hiveMusic;
          //      break;
          //  case 5:
          //      audioSource.clip = defenseMusic;
          //      break;
           // case 6:
          //      audioSource.clip = menuMusic;
          //      break;
          //  default:
          //      audioSource.clip = menuMusic;
           //     break;
        //}
       // audioSource.Play();
   // }

    //public void ChangeMusic(int id)
   // {   
    //    StartCoroutine(FadeOut(musicSource, 0.3f, id));
    //}


    //public void SetVolumeFromSlider() 
    //{
    //    SetVolume(soundSlider.value);
    //}

    //public void RefreshSlider(float _value) 
    //{
    //    soundSlider.value = _value;
    //}

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}


