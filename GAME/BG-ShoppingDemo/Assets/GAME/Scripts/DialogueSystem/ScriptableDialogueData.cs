using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// Could create a list of dialogues or ids of localized texts for the dialogues of each level.
/// Example level1Dialogues, level2Dialogues and changing the plain text for an id for localized text.
/// </summary>
[CreateAssetMenu(fileName = "DialoguesData", menuName = "ScriptableObjects/ScriptableDialoguesData")]
public class ScriptableDialogueData : ScriptableObject
{
    public Dialogue[] dialogues;

    public Dialogue GetDialogue(int id)
    {
        foreach (Dialogue dialogue in dialogues)
        {
            if(dialogue.id == id)
                return dialogue;
        }
        return null;
    }
}
