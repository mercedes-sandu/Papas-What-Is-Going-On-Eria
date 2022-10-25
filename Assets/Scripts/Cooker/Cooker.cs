using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cooker : MonoBehaviour, IInteractable
{
    /// <summary>
    /// The UI canvas corresponding to the cooker.
    /// </summary>
    [SerializeField] private GameObject cookerCanvas;
    
    /// <summary>
    /// Calls for the UI to be updated.
    /// </summary>
    /// <param name="interactor">The interactor component.</param>
    /// <returns>True if the interaction was successful, false otherwise.</returns>
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interacted with cooker.");
        cookerCanvas.SetActive(true);
        return true;
    }
}