using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManage : MonoBehaviour
{
    private bool isAlive=true;
    public float health = 100f;
    public GameObject deathEffect;
    public GameObject gun;
    public GameObject crosshair;
    public GameObject GameOverMenu;
    public GameObject pauseMenu;

    public void Death()
    {
        if (isAlive)
        {
            
                Instantiate(deathEffect, transform.position, Quaternion.identity);
                isAlive = false;
                //Disable Player
                GetComponent<PlayerMovement>().enabled = false;
                gun.SetActive(false);
                crosshair.SetActive(false);

                //Cursor
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.None;
                pauseMenu.GetComponent<PauseMenu>().isGameOver = true;
                //Enable GameOverMenu
                GameOverMenu.SetActive(true);

            

        }

    }
}
