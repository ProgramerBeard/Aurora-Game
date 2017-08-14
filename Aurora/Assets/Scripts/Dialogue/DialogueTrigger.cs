using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

	public Dialogue[] dialogue;

	// This is just a way for dialogue to be trigged in game.
	public void TriggerDialogue () {
		FindObjectOfType <DialogueManager> ().StartDialogue (dialogue);
	}
}