using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooker : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject cookerCanvas;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="interactor"></param>
    /// <returns></returns>
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interacting with cooker");
        cookerCanvas.SetActive(true);
        return true;
    }
}
