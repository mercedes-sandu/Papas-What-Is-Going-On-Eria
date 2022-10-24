using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] private Image sodaStream;
    
    // todo: make the cup mask

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        gameObject.SetActive(false);
    }

    public void PourSoda(GameObject soda)
    {
        
    }
    
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
