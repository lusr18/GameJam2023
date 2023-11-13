using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NLPNPC : MonoBehaviour
{
    public Dialogue dialogue;
    private bool playerInRange = false;
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate(){
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
            dialogue.sentences = FindObjectOfType<GameManager>().GetDialogue(gameObject.tag);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

}
