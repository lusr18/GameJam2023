using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    
    public Dialogue dialogue;

    private bool playerInRange = false;

    [SerializeField] Transform target;
    private NavMeshAgent agent;
    Animator animator;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = GetComponent<Animator>();
    }


    private void FixedUpdate(){
        if(playerInRange == false){
            agent.SetDestination(target.position);
        }
        if(agent.velocity.magnitude != 0){
            animator.SetFloat("Horizontal", agent.velocity.x);
            animator.SetFloat("Vertical", agent.velocity.y);       
        }
        animator.SetFloat("Speed", agent.velocity.sqrMagnitude);
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = true;
            agent.SetDestination(transform.position);
        }
    }

    void OnTriggerExit2D(Collider2D other){
        if(other.CompareTag("Player")){
            playerInRange = false;   
            agent.SetDestination(target.position);
        }
    }

    void OnMouseDown(){
        if(playerInRange){
            dialogue.sentences = FindObjectOfType<GameManager>().GetDialogue(gameObject.tag);
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

}
