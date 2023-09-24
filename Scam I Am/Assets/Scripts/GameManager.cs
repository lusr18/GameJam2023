using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    
    public int victimCount = 0;
    public int currentLevel = 0;

    void Update(){
        if(victimCount == 1){
            currentLevel = 1;
        }
    }

    Dictionary<string, string[]> levelZero = new Dictionary<string, string[]>
    {
        { "Boss", new string[] { "WHAT'CHA LOOKIN AT BIG BAD BOSS FOR!!!", "SIT AT A CALL DESK!!!", "GET BACK TO WORK!!!" } },
        { "Amelia", new string[] { "Hello...", "Nice to meet you, I'm Amelia!" } },
        { "Adam", new string[]{"Yo~"}},
        { "Rob", new string[]{"Go to sit at a desk with a phone and start scamming", "or or or I'll report you to the boss!"}}
    };

    Dictionary<string, string[]> levelOne = new Dictionary<string, string[]>
    {
        { "Boss", new string[] { "OH?! BEGINNER'S LUCK!", "MAYBE I'LL GIVE YOU A RAISE!", "KEEP SCAMMING!!!" } },
        { "Amelia", new string[] { "Heard you got a scam through...", "Poor old lady...", "I wish we didn't have to keep doing this...", "Maybe if we find evidence and call the police..." } },
        { "Adam", new string[] {"Yo~ Nicee Bro~", "So many phones...", "Where are our phones?"}}
    };


    public string[] GetDialogue(string tag){
        if(currentLevel == 0){
            return levelZero[tag];
        }
        else if(currentLevel == 1){
            return levelOne[tag];
        }
        else{
            return new string[] {""};
        }
    }


}
