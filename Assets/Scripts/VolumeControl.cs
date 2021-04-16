using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    //public AudioSource sound;
    public AudioMixer audioMixer;

    private float vol; //Variable pour Get le volume
    private int qual; //Variable pour Get la quality

    private void Awake()
    {
       vol = PlayerPrefs.GetFloat("volume"); //vol devient egal au Set du volume
        ChangeVolume(vol); //Change le volume selon le PlayerPrefs
       qual = PlayerPrefs.GetInt("quality"); //qual devient egal au Set du quality
        ChangeQuality(qual); //Change la quality selon le PlayerPrefs
    }

    public void ChangeVolume(float volume)
    {
        audioMixer.SetFloat("gameVolume", Mathf.Log10(volume) * 20);
        PlayerPrefs.SetFloat("volume", volume);//Set le volume dans les PlayerPrefs
    }

    public void ChangeQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
        PlayerPrefs.SetInt("quality", quality); //Set la quality dans les PlayerPrefs
    }
}
