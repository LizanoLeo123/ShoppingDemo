using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] float interactDistance = .5f;
    [SerializeField] LayerMask interactableLayer;
    [SerializeField] PlayerMovement playerMovement;
    private bool canInteract = true;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            if(canInteract)
            {
                if(FindObjectOfType<UI_DialogueManager>().isHidden) //Can only interact if there is no dialogues open
                {
                    Interact();
                }
            }
        }
    }

    private void Interact()
    {
        if (canInteract)
        {
            canInteract = false;

            Vector3 direction = new Vector3 (playerMovement.moveDirection.x, playerMovement.moveDirection.y, 0);
            if (direction.x == 0 && direction.y == 0) direction = Vector3.up; //Interact up and down if player is not moving
            RaycastHit2D interactHit = Physics2D.Raycast(transform.position, direction, interactDistance, interactableLayer);
            Debug.DrawRay(transform.position, direction * interactDistance, Color.magenta, 1f);
            if (interactHit.collider != null)
            {
                //Debug.Log("Found " + interactHit.collider.transform.name);
                interactHit.collider.gameObject.GetComponent<InteractableObject>()?.TriggerInteract();
            }

            StartCoroutine(InteractCooldown());
        }
    }

    IEnumerator InteractCooldown()
    {
        yield return new WaitForSeconds(.3f); //Interaction cooldown
        canInteract = true;
    }
}
