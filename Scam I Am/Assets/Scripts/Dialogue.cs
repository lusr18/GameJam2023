using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable] // to be able to show in unity inspector
public class Dialogue
{
    public string name;
    public Sprite sprite;
    [TextArea(3, 10)]
    public string[] sentences;
}
