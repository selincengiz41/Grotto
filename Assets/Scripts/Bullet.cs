using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Bullet : MonoBehaviour
{
    public float speed = 100f;
    public float lifeTime=3f;

    public bool  enemy_bullet=false;
    public float bullet_radius = 0.5f;
    public LayerMask player_Layer;
    public GameObject EnemyhitEffect;
    public AudioClip hit_sound;
    public GameObject hitEffect;


    private void Update()
    {
        transform.Translate(Vector3.forward*Time.deltaTime*speed);

        lifeTime -= Time.deltaTime;
        if (lifeTime <= 0)
        {
            Destroy(this.gameObject);
        }

        //Enemy bullet
        if (enemy_bullet)
        {
            if (Physics.CheckSphere(transform.position, bullet_radius,player_Layer))
            {
                Instantiate(hitEffect, GameObject.FindGameObjectWithTag("Player").transform.position, Quaternion.identity);
                GameObject.FindGameObjectWithTag("HealthBar").GetComponent<HealthMenu>().DecreaseHealth();
              
              
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManage>().health -= 25;
              
                if (GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManage>().health <= 0)
                {

                    GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerManage>().Death();
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameObject drone = other.gameObject.transform.parent.gameObject;
            drone.GetComponent<Drone>().health -= 50;
            drone.GetComponent<AudioSource>().PlayOneShot(hit_sound);
            print(drone.GetComponent<Drone>().health);
            Instantiate(EnemyhitEffect, transform.position, Quaternion.identity);
        }

        else
        {

          
            Instantiate(hitEffect, transform.position, Quaternion.identity);
        }
    }
}
