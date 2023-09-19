using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public GameObject player;
    public AudioSource vendingMachine;
    private bool playerInRange;
    // Start is called before the first frame update
    void Start()
    {
        playerInRange = false;
        vendingMachine = GetComponent<AudioSource>();
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
        if(playerInRange){
            vendingMachine.Play();
        }
    }
}
