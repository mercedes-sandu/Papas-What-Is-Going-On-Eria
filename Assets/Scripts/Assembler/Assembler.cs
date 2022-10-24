using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
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
    [SerializeField] private List<Tuple<GameObject, TypeOfIngredient>> _stackedItems
        = new List<Tuple<GameObject, TypeOfIngredient>>();
    
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
    /// <param name="type">The ingredient type of the item to be added.</param>
    public void AddItem(GameObject item, TypeOfIngredient type)
    {
        _stackedItems.Add(new Tuple<GameObject, TypeOfIngredient>(item, type));
    }
    
    /// <summary>
    /// Returns the list of currently stacked items in the assembler canvas.
    /// </summary>
    /// <returns>The list of stacked items.</returns>
    public List<Tuple<GameObject, TypeOfIngredient>> GetStackedItems() => _stackedItems;
}
