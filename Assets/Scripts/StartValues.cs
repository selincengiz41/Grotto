using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartValues : MonoBehaviour
{
    private void Awake()
    {
        //Set mouse Sensitivity
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().mouseSensitivity = PlayerPrefs.GetFloat("mouseSensitivity",200    );
    }


}
