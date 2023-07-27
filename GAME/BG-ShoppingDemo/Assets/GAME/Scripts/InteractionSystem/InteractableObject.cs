using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

// I'm recicled most of this code from my game MOONSHOT.
public class InteractableObject : MonoBehaviour
{
    public Collider2D interactionCollider; //Going to turn this off when a dialogue is open

    //Interactable script to trigger the events
    [SerializeField] UnityEvent OnInteract;

    public void TriggerInteract()
    {
        OnInteract.Invoke();
    }
}
