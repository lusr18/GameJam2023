using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MissionManager : MonoBehaviour
{
    public Button button1;
    public Button button2;
    public Button button3;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    private int choice;
    private bool coldcall = true;
    private Mission mission;
    public Dialogue dialogue;

    private int missiontype;
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(delegate { SetChoice(0); } );
        button2.onClick.AddListener(delegate { SetChoice(1); } );
        button3.onClick.AddListener(delegate { SetChoice(2); } );
    }

    public void InitMission(){
        //string[] temp = new string[]{"Ugh...have to gain his trust to overthrow him...", "Guess I have to keep scamming...", "ring ring ring..."};
        //dialogue.sentences = temp;
        //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        button3.gameObject.SetActive(true);
        if (FindObjectOfType<GameManager>().currentLevel == 2){
            string[] temp = new string[]{"You have scammed enough victims of good money...", "You have earned the trust of coworkers and your boss...", "Maybe stop scamming and see what else you can do to stop them now!"};
            dialogue.sentences = temp;
            FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        } else{
            animator.SetBool("isOpen", true);
            dialogueText.text = "pick a tactic and coldcall...";
            button1.GetComponentInChildren<TextMeshProUGUI>().text = "Medicine";
            button2.GetComponentInChildren<TextMeshProUGUI>().text = "Child kidnapping";
            button3.GetComponentInChildren<TextMeshProUGUI>().text = "I could be your girlfriend!";
        }
    }

    void BeginMission(int choice){
        if(choice == 0){ //mission.tactics[choice] == "Medicine"){
            missiontype = 0;
            dialogueText.text = "OH! i am 80 and i feel like im dying, my kids dont love me or visit";
            button1.GetComponentInChildren<TextMeshProUGUI>().text = "I care about you! buy these meds!";
            button2.GetComponentInChildren<TextMeshProUGUI>().text = "Screw you old woman just buy it";
            button3.gameObject.SetActive(false);
        } else if(choice == 1){
            missiontype = 1;
            dialogueText.text = "What do you mean my five year old child is kidnapped!";
            button1.GetComponentInChildren<TextMeshProUGUI>().text = "I am police trying to help";
            button2.GetComponentInChildren<TextMeshProUGUI>().text = "Give me ransom money!";
            button3.gameObject.SetActive(false);
        } else if(choice == 2){
            missiontype = 2;
            dialogueText.text = "I'm so lonely, are you really a girl";
            button1.GetComponentInChildren<TextMeshProUGUI>().text = "I can be your girlfriend if you buy me gucci...";
            button2.GetComponentInChildren<TextMeshProUGUI>().text = "Ew you're creepy";
            button3.gameObject.SetActive(false);
        }
    }

    void MiddleMission(int choice){
        if(missiontype == 0){ 
            if(choice == 0){
                dialogueText.text = "Thanks I will buy your meds, my bank account is 5555-5555";
                FindObjectOfType<GameManager>().ScamSuccessful();
                animator.SetBool("isOpen", false);
            } else if(choice == 1){
                dialogueText.text = "You're rude! Goodbye!";
                animator.SetBool("isOpen", false);
            }
        } else if(missiontype == 1){
            if(choice == 0){
                dialogueText.text = "You're number is not police! I'm hanging up!";
                animator.SetBool("isOpen", false);
            } else if(choice == 1){
                dialogueText.text = "Ok! Ok! My bank acount is 4444-4444";
                FindObjectOfType<GameManager>().ScamSuccessful();
                animator.SetBool("isOpen", false);
            }
        } else if(missiontype == 2){
            if(choice == 0){
                dialogueText.text = "Ok! My bank account is 3333-3333!";                
                FindObjectOfType<GameManager>().ScamSuccessful();
                animator.SetBool("isOpen", false);
            } else if(choice == 1){
                dialogueText.text = "You're rude! Screw you! *SLAM PHONE*";
                animator.SetBool("isOpen", false);
            }
        }
    }

    private void SetChoice(int userChoice){
        if(coldcall == true){
            if(random() == 1){
                //start that mission
                //string[] temp = new string[]{"ring ring ring...", "A victim picked up!"};
                //dialogue.sentences = temp;
                //FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
                print("cold call succeeded");
                BeginMission(userChoice);
                coldcall = false;
            } else{
                print("cold call failed");
                //must keep cold calling
                InitMission();
            }
        } else{
            // mission already started
            MiddleMission(userChoice);
        }
    }

    public int random()
    {
        return Random.Range(1, 4);
    }

    public void EndMission(){
        animator.SetBool("isOpen", false);
        coldcall = true;
    }
}
