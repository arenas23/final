using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public AudioSource[] music;
    public AudioSource[] SFX;

    public AudioMixerGroup masterMixer, musicMixer, sfxMixer;

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

    public void SetMusicLevel()
    {
        musicMixer.audioMixer.SetFloat("MusicVol", GameManager.Instance.sliderMusic.value);
    }

    public void SetSFXLevel()
    {
        sfxMixer.audioMixer.SetFloat("SFXVol", GameManager.Instance.sliderSFX.value);
    }
    public void SetMasterevel()
    {
        sfxMixer.audioMixer.SetFloat("MasterVol", GameManager.Instance.sliderMaster.value);
    }
}


