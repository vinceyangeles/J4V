using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour {

    //Declaring the spawnPoint of the player
    [SerializeField] Transform spawnPoint;

    //Declaring the player
    public GameObject player;

    //Declaring the rigidbody within the player
    private Rigidbody2D rigi;


    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.transform.CompareTag("Player"))
        {
            //spawns the player back to the allocated EGO spawnpoint
            col.transform.position = spawnPoint.position;
            //spawn with it's rotation. (can be fiddled with if you want)
            col.transform.eulerAngles = new Vector2(0, 0);

            //Accessing the rigidbody from the player
            rigi = player.GetComponent<Rigidbody2D>();

            //adding the velocity when it spawns so it doesn't go everywhere
            //[STILL A WORK IN PROGRESS]
            rigi.velocity = new Vector2(0, 0);
        }
    }
}
