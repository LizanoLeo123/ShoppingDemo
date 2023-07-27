using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalloutBehavior : MonoBehaviour
{
    [SerializeField] GameObject interactSprite;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.transform.parent.name);
        if(collision.transform.parent.CompareTag("Player"))
            ShowUI(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(collision.transform.parent.name);
        if (collision.transform.parent.CompareTag("Player"))
            ShowUI(false);
    }

    public void ShowUI(bool value)
    {
        interactSprite.SetActive(value);
        if(value )
        {
            // Do a couple shakes to catch attention
            Sequence mySequence = DOTween.Sequence();
            mySequence.Append(interactSprite.transform.DOShakePosition(1.0f, strength: new Vector3(0, .2f, 0), vibrato: 4, randomness: 0, snapping: false, fadeOut: false));
            mySequence.Play();
        }
    }
}
