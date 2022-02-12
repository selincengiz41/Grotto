using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    private bool isGamePaused=false;
    public GameObject pauseMenu;
    public bool isGameOver=false;
    public GameObject Pistol;

    public AudioSource music;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !isGameOver)
        {
            if (!isGamePaused)
            {
                PauseGame();
               
            }

           else
            {
                ResumeGame();
               
            }
        }
    }

    private void PauseGame()
    {
        Time.timeScale = 0;
        isGamePaused = true;
        pauseMenu.SetActive(true);
        //Disable Player movement and pistol
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = false;
        Pistol.GetComponent<Gun>().enabled = false;

        //SetCursor
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        music.Pause();
    }

    private void ResumeGame()
    {
        Time.timeScale = 1;
        isGamePaused = false;
        pauseMenu.SetActive(false);
        //Enable player movement and pistol
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().enabled = true;
        Pistol.GetComponent<Gun>().enabled = true;

        //SetCursor
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        music.UnPause();


    }
}
