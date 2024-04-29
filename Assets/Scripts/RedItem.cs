using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedItem : MonoBehaviour
{
    GameObject player;

    public float speed;

    bool pickedUp = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if(!PauseMenu.isPaused){
            Vector2 playerPos = new Vector2(player.transform.position.x, player.transform.position.y);

            if(!pickedUp){
                transform.position = new Vector2(transform.position.x + speed, transform.position.y);
            } else{
                transform.position = playerPos;    
            }
        }
    }       
    

    void OnTriggerEnter2D(Collider2D col){
        if(col.gameObject.tag == "Player"){
            if(player.GetComponent<PlayerController>().canPickUp){
                pickedUp = true;
                player.GetComponent<PlayerController>().pickUpCount++;
            }            
        }

        if(col.gameObject.tag == "RedZone"){
            player.GetComponent<PlayerController>().score++;
            Destroy(gameObject);
            player.GetComponent<PlayerController>().pickUpCount--;
        }

        if(col.gameObject.tag == "DeathZone"){
            player.GetComponent<PlayerController>().health--;
            Destroy(gameObject);
        }
    }
}
