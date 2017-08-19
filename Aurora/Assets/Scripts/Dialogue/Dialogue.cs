using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Dialogue
{

    // Just a model for any dialogue. It is more like container for all the parts of the diagloue box.

    public string name;
    public string rank;
    public Sprite characterPortrait;

    [TextArea(3, 10)]
    public string[] sentences;
}