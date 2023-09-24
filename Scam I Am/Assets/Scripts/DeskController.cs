using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeskController : MonoBehaviour
{
    public GameObject desk_empty;
    public GameObject desk_with_person;
    public GameObject player;
    private bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
           playerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = false;
        }
    }

    void OnMouseDown(){
        print("clicking...");
        Debug.Log("");
        if(playerInRange){
            print("");
            if(player.gameObject.GetComponent<SpriteRenderer>().enabled == true){
                player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                desk_empty.SetActive(false);
                desk_with_person.SetActive(true);
                player.GetComponent<PlayerController>().LockMovement();
            } 
            else{
                player.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                desk_empty.SetActive(true);
                desk_with_person.SetActive(false);
                player.GetComponent<PlayerController>().UnlockMovement();
            }
        }
    }

}
