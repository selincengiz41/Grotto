using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserEnemy : MonoBehaviour
{
    RaycastHit hit;
    public LayerMask PlayerLayer;
    public LayerMask obstacle;

    private bool isVisibleLaser;
    public float range=50f;
    private void Update()
    {
        //Laser
        if(Physics.Raycast(transform.position,transform.forward,out hit, range, obstacle))
        {
            GetComponent<LineRenderer>().enabled = true;
            isVisibleLaser = true;
            GetComponent<LineRenderer>().SetPosition(0, transform.position);
            GetComponent<LineRenderer>().SetPosition(1, hit.point);

            GetComponent<LineRenderer>().startWidth = 0.025f + Mathf.Sin(Time.time)/80;
        }
        else
        {
            GetComponent<LineRenderer>().enabled = false;
            isVisibleLaser = false;

        }
        //Kill Player
        if (Physics.Raycast(transform.position,transform.forward,out hit, range, PlayerLayer)){

            if (isVisibleLaser)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    hit.transform.gameObject.GetComponent<PlayerManage>().Death();
                }
            }
        }

    }
}
