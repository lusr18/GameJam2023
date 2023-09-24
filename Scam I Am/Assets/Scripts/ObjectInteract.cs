using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectInteract : MonoBehaviour
{
    public GameObject player;
    //public AudioSource vendingMachine;
    private bool playerInRange;
    // Start is called before the first frame update
    public Dialogue dialogue;
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
        if(playerInRange){
            //vendingMachine.Play();
            if(FindObjectOfType<GameManager>().currentLevel == 2 && gameObject.tag == "OfficePC"){
                dialogue.sentences = new string[]{"Boss let me on his PC", "Found his evidence...", "I'm calling the police! I win!"};
                FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
            }
        }
    }
}
