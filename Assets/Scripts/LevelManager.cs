using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    //Player enter exit     
    public bool player_enter, player_exit;
    //Drone spawn
    public bool Spawned;
    public Transform[] droneSpawners;
    public GameObject drone;
    //Level Spawn
    public GameObject level;
    public GameObject destroyLevel;
    private void Awake()
    {
        player_enter = false;
        player_exit = false;
        Spawned = false;
    
    }
    private void Update()
    {
      
        if(!Spawned)
        {
            if (player_enter)
            {
                //Spawn level
                SpawnLevel();
                //drone spawn
                for (int i = 0; i < droneSpawners.Length; i++)
                {
                    Instantiate(drone, droneSpawners[i].position, Quaternion.identity);
                }
              
                Spawned = true;
            }
           
        }

        if (player_exit)
        {
            Destroy(destroyLevel);
        }
    }
    private void SpawnLevel()
    {
        Vector3 levelLocation = new Vector3(transform.position.x,transform.position.y,transform.position.z+89);
      GameObject obj= Instantiate(level, levelLocation, Quaternion.identity);
        obj.GetComponent<LevelManager>().destroyLevel = this.gameObject;
    }
  
       
    

}
