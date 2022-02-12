using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitLevel : MonoBehaviour
{
    public LevelManager lm;
    private void OnTriggerEnter(Collider other)
    {
        lm.player_exit = true;
    }
}
