using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;

    public UI_DialogueManager dialogueManager; //Should put this on an instance but that might cause small errors that take time to fix.

    [HideInInspector] public Vector2 moveDirection = Vector2.zero; //Need to get the facing direction on the interaction system

    void Update()
    {
        if(dialogueManager.isHidden)
        {
            //Input
            moveDirection.x = Input.GetAxisRaw("Horizontal");
            moveDirection.y = Input.GetAxisRaw("Vertical");
        }
    }

    private void FixedUpdate()
    {
        //Movement
        rb.MovePosition(rb.position + moveDirection * moveSpeed * Time.fixedDeltaTime);
        animator.SetFloat("Horizontal", moveDirection.x);
        animator.SetFloat("Vertical", moveDirection.y);
        animator.SetFloat("Speed", moveDirection.sqrMagnitude);
    }
}
