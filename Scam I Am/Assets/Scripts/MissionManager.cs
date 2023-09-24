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
    private int choice;
    private bool coldcall = true;
    private Mission mission;
    // Start is called before the first frame update
    void Start()
    {
        button1.onClick.AddListener(delegate { SetChoice(0); } );
        button2.onClick.AddListener(delegate { SetChoice(1); } );
        button3.onClick.AddListener(delegate { SetChoice(2); } );
        InitMission();
    }

    void InitMission(){
        dialogueText.text = "pick a tactic...";
        button1.GetComponentInChildren<TextMeshProUGUI>().text = "Medicine";
        button2.GetComponentInChildren<TextMeshProUGUI>().text = "Child kidnapping";
        button3.GetComponentInChildren<TextMeshProUGUI>().text = "I could be your girlfriend!";
    }

    void BeginMission(int choice){
        if(choice == 0){ //mission.tactics[choice] == "Medicine"){
            dialogueText.text = "OH! i am 80 and i feel like im dying, my kids dont love me or visit";
            button1.GetComponentInChildren<TextMeshProUGUI>().text = "I care about you! buy these meds!";
            button2.GetComponentInChildren<TextMeshProUGUI>().text = "Fk you old woman just buy it";
            button3.gameObject.SetActive(false);
        }
    }

    void MiddleMission(int choice){
        if(choice == 0){ //chose to be nice
            dialogueText.text = "OH! thanks I will buy your meds, my bank account is 5555-5555";
            FindObjectOfType<GameManager>().currentLevel++;
        }
    }

    private void SetChoice(int userChoice){
        if(coldcall == true){
            if(random() == 1){
                //start that mission
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
}
