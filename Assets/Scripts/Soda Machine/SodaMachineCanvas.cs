using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SodaMachineCanvas : MonoBehaviour
{
    /// <summary>
    /// The soda cup.
    /// </summary>
    [SerializeField] private GameObject cup;

    /// <summary>
    /// The fill line for the soda cup.
    /// </summary>
    [SerializeField] private GameObject fillLine;

    /// <summary>
    /// The soda stream.
    /// </summary>
    [SerializeField] private Image sodaStream;
    
    // todo: make the cup mask

    /// <summary>
    /// The soda being poured.
    /// </summary>
    private GameObject _pouredSoda;
    
    /// <summary>
    /// The y-value of where the soda was filled to.
    /// </summary>
    private float _fillAmount;

    /// <summary>
    /// Sets the UI canvas to be inactive.
    /// </summary>
    void Start()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Pours the specified soda.
    /// </summary>
    /// <param name="soda">The soda to be poured.</param>
    public void PourSoda(GameObject soda)
    {
        _pouredSoda = soda;
    }

    public void FinishPouringSoda()
    {
        // todo set _fillAmount
    }
    
    /// <summary>
    /// Closes the soda machine canvas.
    /// </summary>
    public void CloseCanvas()
    {
        gameObject.SetActive(false);
    }
    
    /// <summary>
    /// Completes the soda order.
    /// </summary>
    public void CompleteSodaOrder()
    {
        GameEvent.CompleteSodaOrder(Order.Instance.GetSoda(), _pouredSoda, _fillAmount);
    }
}