using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    //Look
    public LayerMask obstacleLayer;
    RaycastHit hit;
    public Vector3 offset;
    //Fire 
    public GameObject bullet;
    public Transform gun;
    //Cooldown
    private float coolDown;
    //gunShot audio
    public AudioClip gunshot;
    private void Update()
    {
        //Look
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity, obstacleLayer))
        {
            transform.LookAt(hit.point);
            transform.rotation *= Quaternion.Euler(offset);
        }
        //Fire
        if (coolDown > 0)   
        {
            coolDown -= Time.deltaTime;
        }

        if (Input.GetMouseButtonDown(0)&& coolDown<=0)
        {
            Instantiate(bullet, gun.position, transform.rotation * Quaternion.Euler(90, 0, 0));
            coolDown = 0.25f;
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(gunshot);
            GetComponent<Animator>().SetTrigger("shot");

        }
    }
}
