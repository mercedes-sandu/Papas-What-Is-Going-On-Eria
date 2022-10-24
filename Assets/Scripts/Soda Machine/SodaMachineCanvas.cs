using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SodaMachineCanvas : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject cup;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject fillLine;
    
    /// <summary>
    /// 
    /// </summary>
    public void CloseCanvas()
    {
        gameObject.SetActive(false);
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void CompleteSodaOrder()
    {
        
    }
}
