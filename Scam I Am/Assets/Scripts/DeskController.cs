using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeskController : MonoBehaviour
{
    public GameObject player;
    private bool playerInRange;
    public Dialogue dialogue;
    private Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
        animator = GetComponent<Animator>();
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
        if(playerInRange){
            print("");
            if(player.gameObject.GetComponent<SpriteRenderer>().enabled == true){
                player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
                animator.SetBool("personSitting", true);
                player.GetComponent<PlayerController>().LockMovement();
                FindObjectOfType<MissionManager>().InitMission();
            } 
            else{
                player.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                animator.SetBool("personSitting", false);
                player.GetComponent<PlayerController>().UnlockMovement();
                FindObjectOfType<MissionManager>().EndMission();
            }
        }
    }

}
