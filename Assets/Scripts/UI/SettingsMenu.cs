using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;


public class SettingsMenu : MonoBehaviour
{
    public GameObject Main;
    public GameObject settings;
    public AudioMixer audioMixer;

    private bool isFullScreen=true;
   
    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
    }

    public void ReturnMenu()
    {
        settings.SetActive(false);
        Main.SetActive(true);

      
    }
    public void SetFullscreen(bool value)
    {
        Screen.fullScreen = value;
        isFullScreen = value;
    }

    public void SetMouseSensitivity(float value)
    {
        PlayerPrefs.SetFloat("mouseSensitivity", value);     
    }

    public void SetMasterVolume(float value)
    {
        audioMixer.SetFloat("MasterVolume", value);
    }
    public void SetMusicVolume(float value)
    {
        audioMixer.SetFloat("MusicVolume", value);

    }
    public void SetResulation(int index)
    {
        if (index == 0)
        {
            Screen.SetResolution(1920, 1080, isFullScreen);
        }
        else if (index == 1)
        {
            Screen.SetResolution(800, 800, isFullScreen);
        }

    }

}
