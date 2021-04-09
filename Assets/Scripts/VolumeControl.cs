using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class VolumeControl : MonoBehaviour
{
    //public AudioSource sound;
    public AudioMixer audioMixer;

    public void ChangeVolume(float volume)
    {
        Debug.Log("volume is: " + volume);
        audioMixer.SetFloat("gameVolume", Mathf.Log10(volume) * 20);
    }

    public void ChangeQuality(int quality)
    {
        QualitySettings.SetQualityLevel(quality);
    }
}
