using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{
    public GameObject settings;
    public GameObject Main;

    public void PlayButton()
    {
        SceneManager.LoadScene("Main");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
    public void SettingsButton()
    {
        Main.SetActive(false);  

        settings.SetActive(true);

    }
}
