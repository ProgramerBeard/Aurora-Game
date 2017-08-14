using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrintDate : MonoBehaviour {

	public TimeManager tm;
	public Text updateText;

	void Update () {
		updateText.text = tm.curTime.GetAsString ();
	}
}
