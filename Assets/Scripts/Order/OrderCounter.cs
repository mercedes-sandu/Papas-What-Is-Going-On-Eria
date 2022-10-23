using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

[RequireComponent(typeof(Order))]
public class OrderCounter : MonoBehaviour, IInteractable
{
    /// <summary>
    /// The order canvas.
    /// </summary>
    [SerializeField] private GameObject orderCanvas;
    
    /// <summary>
    /// The current order.
    /// </summary>
    private Order _order;

    /// <summary>
    /// Gets the order.
    /// </summary>
    void Start()
    {
        _order = GetComponent<Order>();
    }
    
    /// <summary>
    /// Initializes the order and calls for the UI to be updated.
    /// </summary>
    /// <param name="interactor">The interactor component.</param>
    /// <returns>True if the interaction was successful, false otherwise.</returns>
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interacting with order counter.");
        _order.InitializeOrder();
        var canvas = orderCanvas.GetComponent<OrderCanvas>();
        canvas.UpdateOrder(_order.GetIngredientsDict(), _order.GetCookTime(), _order.GetSoda());
        return true;
    }
}