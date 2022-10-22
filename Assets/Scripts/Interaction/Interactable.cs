using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public abstract class Interactable : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private void Reset()
    {
        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    
    /// <summary>
    /// 
    /// </summary>
    public abstract void Interact();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerControl>().OpenInteractableIcon();
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            col.GetComponent<PlayerControl>().CloseInteractableIcon();
        }
    }
}
