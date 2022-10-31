using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingCounter : MonoBehaviour, IInteractable
{
    /// <summary>
    /// Completes the order.
    /// </summary>
    /// <param name="interactor">The interactor component.</param>
    /// <returns>True if the interaction was successful, false otherwise.</returns>
    public bool Interact(Interactor interactor)
    {
        if (Order.Instance.GetIngredientsDict().Count > 0)
        {
            GameEvent.CompleteOrder();
        }
        return true;
    }
}