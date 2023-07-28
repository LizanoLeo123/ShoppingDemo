using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class UI_DialogueManager : MonoBehaviour
{
    public ScriptableDialogueData levelDialogues;
    public Image characterSprite;
    public GameObject dialogueBox;
    public TMP_Text characterName;
    public TMP_Text dialogueText;
    [HideInInspector] public bool isHidden = true;
    //public float xValue;

    private Dialogue currentDialogue;

    public void ChangeDialogue(int id)
    {
        currentDialogue = levelDialogues.GetDialogue(id);
        if (currentDialogue != null)
        {
            characterSprite.sprite = currentDialogue.character;
            characterName.text = currentDialogue.name;
            dialogueText.text = currentDialogue.text;
        }
        else
        {
            Debug.Log("Couldn't find dialogue");
        }
    }

    private void Update()
    {
        if(Input.GetKeyUp(KeyCode.Return)) { 
            NextDialogue();
        }
    }

    public void NextDialogue()
    {
        if(currentDialogue == null || currentDialogue.nextDialogue == -1)
        {
            OnDialogueFinish();
            return;
        }
        ChangeDialogue(currentDialogue.nextDialogue);
    }

    public void OnDialogueStart()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(dialogueBox.transform.DOMove(new Vector3(Screen.width/2, 162, 0), 1f));
        mySequence.Play();
        isHidden = false;
    }

    public void OnDialogueFinish()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(dialogueBox.transform.DOMove(new Vector3(Screen.width/2, -385, 0), 1f));
        mySequence.Play();
        isHidden = true;
    }
}
