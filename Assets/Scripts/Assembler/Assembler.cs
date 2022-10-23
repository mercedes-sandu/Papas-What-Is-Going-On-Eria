using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assembler : MonoBehaviour, IInteractable
{
    /// <summary>
    /// The UI canvas corresponding to the assembler.
    /// </summary>
    [SerializeField] private GameObject assemblerCanvas;
    
    /// <summary>
    /// Calls for the UI to be updated.
    /// </summary>
    /// <param name="interactor">The interactor component.</param>
    /// <returns>True if the interaction was successful, false otherwise.</returns>
    public bool Interact(Interactor interactor)
    {
        assemblerCanvas.SetActive(true);
        return true;
    }
}
