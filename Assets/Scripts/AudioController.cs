using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using Random = UnityEngine.Random;
using Slider = UnityEngine.UI.Slider;
using Toggle = UnityEngine.UI.Toggle;

public class AudioController : MonoBehaviour
{
    public AudioClip[] sound;
    public Slider sliderEffects;
    public Slider sliderMusic;
    public Toggle toggleEffects;
    public Toggle toggleMusic;
    private AudioSource Effects => GetComponent<AudioSource>();
    private static AudioSource Music => GameObject.Find("Canvas").transform.GetComponent<AudioSource>();
        
    private void Start()
    {
        Effects.volume = PlayerPrefs.GetFloat("sliderEffects", 1f);
        Music.volume = PlayerPrefs.GetFloat("sliderMusic", 1f);
        
        Effects.mute = Convert.ToBoolean(PlayerPrefs.GetInt("toggleEffects", 0));
        Music.mute = Convert.ToBoolean(PlayerPrefs.GetInt("toggleMusic", 0));

        toggleMusic.isOn = !Music.mute;
        toggleEffects.isOn = !Effects.mute;
        sliderMusic.value = Music.volume;
        sliderEffects.value = Effects.volume;

        toggleMusic.transform.GetComponent<SwitchToggle>().switchToggle += MusicSwitch;
        toggleEffects.transform.GetComponent<SwitchToggle>().switchToggle += EffectsSwitch;
    }

    public void PlaySound(AudioClip clip, bool destroyed = false, float p1 = 0.85f, float p2 = 1.2f)
    {
        Effects.pitch = Random.Range(p1, p2);

        if (Effects.mute) return;
        if (destroyed) AudioSource.PlayClipAtPoint(clip, Camera.main!.transform.position, sliderEffects.value);
        else Effects.PlayOneShot(clip, sliderEffects.value);
    }
    
    public void SetVolumeEffects()
    {
        Effects.volume = sliderEffects.value;
        PlayerPrefs.SetFloat("sliderEffects", sliderEffects.value);
    }
    
    public void SetVolumeMusic()
    {
        Music.volume = sliderMusic.value;
        PlayerPrefs.SetFloat("sliderMusic", sliderMusic.value);
    }

    private void EffectsSwitch(bool on)
    {
        Effects.mute = !on;
        PlayerPrefs.SetInt("toggleEffects", on ? 0 : 1);
    }

    private static void MusicSwitch(bool on)
    {
        Music.mute = !on;
        PlayerPrefs.SetInt("toggleMusic", on ? 0 : 1);
    }
}
