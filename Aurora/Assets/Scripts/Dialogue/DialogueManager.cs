using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{

    public Text nameText;
    public Text rankText;
    public Text dialogueText;
    public Image characterPortrait;

    private Queue<string> names;
    private Queue<string> ranks;
    private Queue<string> sentences;
    private Queue<Sprite> images;

    // Starts the dialogue. It clears the Queues the for every dialogue object in the dialouge parameter array it add each part of that object to there respective Queues.
    public void StartDialogue(Dialogue[] dialogue)
    {
        names.Clear();
        ranks.Clear();
        sentences.Clear();
        images.Clear();

        foreach (Dialogue dialogueLine in dialogue)
        {
            //nameText.text = dialogueLine.name;
            //rankText.text = dialogueLine.rank;
            foreach (string sentence in dialogueLine.sentences)
            {
                names.Enqueue(dialogueLine.name);
                ranks.Enqueue(dialogueLine.rank);
                images.Enqueue(dialogueLine.characterPortrait);
                sentences.Enqueue(sentence);
            }
        }

        DisplayNextSentence();
    }

    // Displays the next sentance and if there are no more sentance a EndDialogue () method should be clalled.
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            //EndDialogue ();
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();
        string rank = ranks.Dequeue();
        Sprite portrait = images.Dequeue();

        StopAllCoroutines();
        nameText.text = name;
        //dialogueText.text = sentence;
        StartCoroutine(TypeSentence(sentence));
        rankText.text = rank;
        characterPortrait.sprite = portrait;
    }

    // Types the sentence to the dialouge box.
    private IEnumerator TypeSentence(string sentence)
    {
        dialogueText.text = "";

        foreach (char letter in sentence.ToCharArray ())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void Start()
    {
        sentences = new Queue<string>();
        names = new Queue <string>();
        ranks = new Queue <string>();
        images = new Queue <Sprite>();
    }
}