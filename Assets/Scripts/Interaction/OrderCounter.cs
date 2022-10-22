using System.Collections;
using System.Collections.Generic;
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
    private List<GameObject> _orderList = new List<GameObject>();

    void Start()
    {
        _order = GetComponent<Order>();
    }
    
    public override void Interact()
    {
        _order.InitializeOrder();
        _orderList = _order.GetIngredientsList();
        orderCanvas.GetComponent<OrderCanvas>().UpdateOrder(_orderList);
    }
}
