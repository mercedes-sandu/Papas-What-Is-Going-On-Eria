using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrderCanvas : MonoBehaviour
{
    
    
    /// <summary>
    /// Sets the canvas to be inactive initially.
    /// </summary>
    void Start()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Updates the order ticket UI with the specified ingredients list and sets the canvas to be active.
    /// </summary>
    /// <param name="ingredients">The list of ingredients for this order ticket.</param>
    public void UpdateOrder(List<GameObject> ingredients)
    {
        gameObject.SetActive(true);
    }
}
