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
    /// The list of currently stacked items in the assembler canvas.
    /// </summary>
    [SerializeField] private List<GameObject> _stackedItems = new List<GameObject>(); 
    
    /// <summary>
    /// Calls for the UI to be updated.
    /// </summary>
    /// <param name="interactor">The interactor component.</param>
    /// <returns>True if the interaction was successful, false otherwise.</returns>
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interacted with assembler.");
        assemblerCanvas.SetActive(true);
        var canvas = assemblerCanvas.GetComponent<AssemblerCanvas>();
        canvas.AcquireMeat();
        return true;
    }
   
    /// <summary>
    /// Adds the specified item to the list of currently stacked items in the assembler canvas.
    /// </summary>
    /// <param name="item">The item to be added.</param>
    public void AddItem(GameObject item)
    {
        _stackedItems.Add(item);
    }
    
    /// <summary>
    /// Returns the list of currently stacked items in the assembler canvas.
    /// </summary>
    /// <returns>The list of stacked items.</returns>
    public List<GameObject> GetStackedItems() => _stackedItems;
}
