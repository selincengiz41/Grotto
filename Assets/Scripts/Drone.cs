using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drone : MonoBehaviour
{
    private Transform player;
    private Vector3 offset;
    public float speed=7;
    public float follow_distance = 10f;

    private float coolDown=2f;
    public GameObject mesh;
    public GameObject bullet;
    public Transform bullet_position;
    public float health = 100f;
    public GameObject drone_death;
    public AudioClip death_sound;

    public AudioClip shot;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        offset.x = 90;
        offset.z = -90;
    }
    private void Update()
    {
        FollowPlayer();
        Shot();
        Death();
    }
    private void FollowPlayer()
    {
    //Look player

        transform.LookAt(player.position);
        transform.rotation *= Quaternion.Euler(offset);

        //Move to player
        if (Vector3.Distance(player.position, transform.position) > follow_distance)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed * -1);
        }
        else{
            transform.RotateAround(player.position, transform.forward, Time.deltaTime * speed*Random.Range(0.2f,3f));
        }
     
    }
    private void Shot()
    {
        if (coolDown > 0)
        {
            coolDown -= Time.deltaTime;
        }
        else
        {
            coolDown = 2f;
            //Shot
           GetComponent<AudioSource>().PlayOneShot(shot);
            mesh.GetComponent<Animator>().SetTrigger("shot");
            Instantiate(bullet, bullet_position.position,transform.rotation*Quaternion.Euler(new Vector3(0,-90,0)));

        }

    }  
    private void Death()
    {
        if (health <= 0)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<AudioSource>().PlayOneShot(death_sound);

            Instantiate(drone_death, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
