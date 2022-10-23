using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembler : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject assemblerCanvas;
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="interactor"></param>
    /// <returns></returns>
    public bool Interact(Interactor interactor)
    {
        assemblerCanvas.SetActive(true);
        return true;
    }
}
