using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevel : MonoBehaviour
{
    public LevelManager lm;

    private void OnTriggerEnter(Collider other)
    {
        lm.player_enter = true;
    }
}
