using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.AI;

public class NPCController : MonoBehaviour
{
    
    public Dialogue dialogue;

    private bool playerInRange = false;

    [SerializeField] Transform target;
    private NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
       if(playerInRange == false)
        agent.SetDestination(target.position);
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
           FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        }
    }

}
