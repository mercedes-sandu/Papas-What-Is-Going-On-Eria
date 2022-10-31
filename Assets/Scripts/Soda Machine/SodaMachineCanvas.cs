using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SodaMachineCanvas : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject[] sodaButtons;
    
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
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Image pouredSoda;
    
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
    /// The canvas component.
    /// </summary>
    private Canvas _canvas;

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        GameEvent.OnOrderComplete += ResetSodaMachineCanvas;
    }
    
    /// <summary>
    /// Sets the UI canvas to be inactive.
    /// </summary>
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    /// <summary>
    /// Pours the specified soda.
    /// </summary>
    /// <param name="index">The index of the soda to be poured.</param>
    public void PourSoda(int index)
    {
        
    }

    /// <summary>
    /// Sets the soda to be poured.
    /// </summary>
    /// <param name="index">The index of the soda to be poured.</param>
    public void SetSoda(int index)
    {
        _pouredSoda = sodaButtons[index];
        // pouredSoda.sprite = _pouredSoda.GetComponent<>()
        for (int i = 0; i < sodaButtons.Length; i++)
        {
            if (i != index)
            {
                sodaButtons[i].GetComponent<Button>().interactable = false;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public void FinishPouringSoda()
    {
        // todo set _fillAmount
    }
    
    /// <summary>
    /// Closes the soda machine canvas.
    /// </summary>
    public void CloseCanvas()
    {
        _canvas.enabled = false;
    }
    
    /// <summary>
    /// Completes the soda order.
    /// </summary>
    public void CompleteSodaOrder()
    {
        GameEvent.CompleteSodaOrder(Order.Instance.GetSoda(), _pouredSoda, _fillAmount);
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void ResetSodaMachineCanvas()
    {
        _pouredSoda = null;
        _fillAmount = 0;
    }
    
    /// <summary>
    /// 
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnOrderComplete -= ResetSodaMachineCanvas;
    }
}