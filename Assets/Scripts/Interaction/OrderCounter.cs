using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

[RequireComponent(typeof(Order))]
public class OrderCounter : MonoBehaviour, IInteractable
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private string prompt;
    
    /// <summary>
    /// 
    /// </summary>
    public string InteractionPrompt => prompt;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject orderCanvas;
    
    /// <summary>
    /// 
    /// </summary>
    private Order _order;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        _order = GetComponent<Order>();
    }
    
    /// <summary>
    /// 
    /// </summary>
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Interacting with order counter");
        _order.InitializeOrder();
        string result = "";
        foreach (var item in _order.GetIngredientsDict().Values)
        {
            result += item.name + " ";
        }
        Debug.Log("ingredients: " + result);
        Debug.Log("cook time: " + _order.GetCookTime());
        Debug.Log("soda: " + _order.GetSoda().name);
        var canvas = orderCanvas.GetComponent<OrderCanvas>();
        canvas.UpdateOrder(_order.GetIngredientsDict(), _order.GetCookTime(), _order.GetSoda());
        // orderCanvas.gameObject.SetActive(true);
        return true;
    }
}
