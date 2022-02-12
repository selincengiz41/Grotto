using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenuSettings : MonoBehaviour
{
    public GameObject settings;
    public GameObject Pause;

    public void MainMenuButton()
    {

        SceneManager.LoadScene("MainMenu");
    }
    public void ExitButton()
    {
        Application.Quit();
    }

    public void SettingsButton()
    {
        Pause.SetActive(false);

        settings.SetActive(true);


    }
}
