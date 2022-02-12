using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
   public void RestartButton()
    {
        SceneManager.LoadScene("Main");
    }

    public void MainMenuButton()
    {

        SceneManager.LoadScene("MainMenu");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
