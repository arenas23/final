//using System;
//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class AudioManager : MonoBehaviour
//{
//    public static AudioManager Instance;
//    public Sound[] musicSounds, sfxSounds;
//    public AudioSource musicSource, sfxSource;


//    private void Awake()
//    {
//        if (Instance == null)
//        {
//            Instance = this;
//            DontDestroyOnLoad(gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }

//    }

//    private void Start()
//    {
//    }

//    public void PlayMusic(string name)
//    {
//        Sound s = Array.Find(musicSounds, x => x.name == name);
//        if (s == null)
//        {
//            Debug.Log("music not found");
//        }
//        else
//        {
//            musicSource.clip = s.audioClip;
//            musicSource.Play();
//        }
//    }

//    public void PlaySfx(string name)
//    {
//        Sound s = Array.Find(sfxSounds, x => x.name == name);
//        if (s == null)
//        {
//            Debug.Log("music not found");
//        }
//        else
//        {
//            sfxSource.PlayOneShot(s.audioClip);
//        }
//    }

//    public void ChangeMusicVolume(float volume)
//    {
//        musicSource.volume = volume;
//    }

//    public void changeSfcVolume(float volume)
//    {
//        sfxSource.volume = volume;
//    }
//}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource[] music;
    public AudioSource[] SFX;

    //public AudioMixerGroup musicMixer, sfxMixer;

    private void Awake()
    {
        Instance = this;
    }
    void Start()
    {
        PlayMusic(0);
       
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayMusic(int musicToPlay)
    {
        music[musicToPlay].Play();
    }

    public void PlaySFX(int sfxPlay)
    {

        SFX[sfxPlay].Play();

    }

    public void StopSFX(int sfxPlay)
    {

        SFX[sfxPlay].Stop();

    }

    //public void SetMusicLevel()
    //{
    //    musicMixer.audioMixer.SetFloat("MusicVol", UIManager.instance.musicVolSlider.value);
    //}

    //public void SetSFXLevel()
    //{
    //    sfxMixer.audioMixer.SetFloat("SFXVol", UIManager.instance.sfxVolSlider.value);
    //}

}


