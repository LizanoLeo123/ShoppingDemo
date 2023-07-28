using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] UnityEvent OnPlayerEnter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.parent != null)
        {
            if (collision.transform.parent.CompareTag("Player"))
            {
                
                OnPlayerEnter.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
