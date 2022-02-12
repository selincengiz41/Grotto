using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Column : MonoBehaviour
{
    public Transform checker;
    public LayerMask player_Layer;

    private Vector3 velocity;
    private bool broke=false;
    private void Update()
    {
        if(Physics.CheckBox(checker.position,new Vector3(1, 1, 1), Quaternion.identity, player_Layer)){

            broke = true;

        }
        if (broke)
        {
            velocity.z -= Time.deltaTime / 200;
            transform.Translate(velocity);

        }
    }
}
