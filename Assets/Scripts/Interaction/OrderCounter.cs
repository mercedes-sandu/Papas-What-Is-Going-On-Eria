using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

[RequireComponent(typeof(Order))]
public class OrderCounter : Interactable
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Canvas orderCanvas;
    
    /// <summary>
    /// 
    /// </summary>
    private Order _order;
    
    /// <summary>
    /// 
    /// </summary>
    private Dictionary<TypeOfIngredient, GameObject> _orderList = new Dictionary<TypeOfIngredient, GameObject>();

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
    public override void Interact()
    {
        _order.InitializeOrder();
        _orderList = _order.GetIngredientsDict();
        orderCanvas.GetComponent<OrderCanvas>().UpdateOrder(_orderList);
    }
}
