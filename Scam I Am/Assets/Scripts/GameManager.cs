using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public int victimCount = 0;
    public int currentLevel = 0;
    public GameObject endPanel;

    Dictionary<string, string[]> levelZero = new Dictionary<string, string[]>
    {
        { "Boss", new string[] { "WHAT'CHA LOOKIN AT BIG BAD BOSS FOR!!!", "SIT AT A CALL DESK!!!", "GET BACK TO WORK!!!" } },
        { "Amelia", new string[] { "Hello...", "Nice to meet you, I'm Amelia!", "Feel free to ask me about anything." } },
        { "Adam", new string[]{"Yo~"}},
        { "Rob", new string[]{"Go to sit at a desk with a phone and start scamming", "or or or I'll report you to the boss!"}}
    };

    Dictionary<string, string[]> levelOne = new Dictionary<string, string[]>
    {
        { "Boss", new string[] { "OH?! BEGINNER'S LUCK!", "MAYBE I'LL GIVE YOU A RAISE!", "KEEP SCAMMING!!!" } },
        { "Amelia", new string[] { "Heard you got a scam through...", "Poor old lady...", "I wish we didn't have to keep doing this...", "Maybe if we find evidence and call the police..." } },
        { "Adam", new string[] {"Yo~ Nicee Bro~", "So many phones...", "Where are our phones?"}},
        { "Rob", new string[]{"You you you! You keep working!", "No wait, no I need the raise", "You stop working! Hmph!"}}
    };

    Dictionary<string, string[]> levelTwo = new Dictionary<string, string[]>
    {
        { "Boss", new string[] { "MAYBE I WILL GIVE YOU A RAISE HAHA!", "GO TO MY OFFICE AND GRAB MY LAPTOP FOR ME WILL YA!" } },
        { "Amelia", new string[] { "I think the boss has evidence on his computer...", "I also saw mean rob put our phones in the closet...", "Maybe if you can get them you can take picture evidence...", "And to call the police..."} },
        { "Adam", new string[] {"Yoo dude you're like, the employee of the month broo"}},
        { "Rob", new string[]{"You you you!", "I need to stop you from calling so I can be employee of the month", "Go get the mop from the closet and clean the bathroom!"}}
    };

    Dictionary<string, string[]> levelThree = new Dictionary<string, string[]>
    {
        { "Boss", new string[] { "Did you fetch my laptop from my office?" } },
        { "Amelia", new string[] { "I think the boss has evidence on his computer...", "I also saw mean rob put our phones in the closet...", "Maybe if you can get them you can take picture evidence...", "And to call the police..."} },
        { "Adam", new string[] {"Yoo dude you're like, the employee of the month broo"}},
        { "Rob", new string[]{"You you you!", "I need to stop you from calling so I can be employee of the month", "Go get the mop from the closet and clean the bathroom!"}}
    };



    public string[] GetDialogue(string tag){
        if(currentLevel == 0){
            return levelZero[tag];
        }
        else if(currentLevel == 1){
            return levelOne[tag];
        }
        else if(currentLevel == 2){
            return levelTwo[tag];
        }
        else{
            return levelThree[tag];
        }
    }

    public void ScamSuccessful(){
        Dialogue dialogue = new Dialogue();
        dialogue.sentences = new string[] {"I did it ... I successfully scammed someone ..."};
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
        victimCount++;
        if(victimCount == 1){
            currentLevel = 1;
        } else if(victimCount == 3){
            currentLevel = 2;
        }
    }

    public void GameOver(){
        // show ui to display game over
        endPanel.SetActive(true);
    }

     public void LoadMenuScene(){
        SceneManager.LoadScene("Menu");
    }

}
