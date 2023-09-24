using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    
    public int victimCount = 0;
    public int currentLevel = 0;

    void Update(){
        if(victimCount == 1){
            currentLevel++;
        }
    }

    Dictionary<string, string[]> levelZero = new Dictionary<string, string[]>
    {
        { "Boss", new string[] { "GET BACK TO WORK!!!" } },
        { "Amelia", new string[] { "Hello...", "Nice to meet you, I'm Amelia!" } },
        { "Adam", new string[]{"Yo~"}}
    };

    Dictionary<string, string[]> levelOne = new Dictionary<string, string[]>
    {
        { "Boss", new string[] { "NICE WORK MAYBE I'LL GIVE YOU A RAISE, KEEP SCAMMING!!!" } },
        { "Amelia", new string[] { "Heard you got a scam through, poor old lady" } },
        { "Adam", new string[]{"Yo~Nicee Bro~"}}
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
