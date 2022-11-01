using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SodaMachineCanvas : MonoBehaviour
{
    /// <summary>
    /// The soda buttons.
    /// </summary>
    [SerializeField] private GameObject[] sodaButtons;

    /// <summary>
    /// The soda liquid images.
    /// </summary>
    [SerializeField] private Texture[] sodaImages;

    /// <summary>
    /// The soda stream.
    /// </summary>
    [SerializeField] private Image sodaStream;

    /// <summary>
    /// The soda prefab which is being poured.
    /// </summary>
    private GameObject _pouredSoda;
    
    /// <summary>
    /// The list of colors for the soda stream.
    /// </summary>
    private readonly Color32[] _sodaColors =
    {
        new Color32(255, 140, 0, 255), 
        new Color32(75, 0, 130, 255), 
        new Color32(0, 255, 0, 255)
    };

    /// <summary>
    /// The canvas component.
    /// </summary>
    private Canvas _canvas;

    /// <summary>
    /// The animator component.
    /// </summary>
    private Animator _anim;

    /// <summary>
    /// Subscribes to GameEvents.
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
        _anim = GetComponent<Animator>();
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    /// <summary>
    /// Sets the soda to be poured and triggers the filling animation.
    /// </summary>
    /// <param name="soda">The soda which is being poured.</param>
    public void PourSoda(GameObject soda)
    {
        _pouredSoda = soda;
        foreach (var button in sodaButtons)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="index"></param>
    public void SetSodaIndex(int index)
    {
        _pouredSoda.GetComponent<RawImage>().texture = sodaImages[index];
        sodaStream.color = _sodaColors[index];
    }

    /// <summary>
    /// Stops the filling animation.
    /// </summary>
    public void FinishPouringSoda()
    {
        
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
        GameEvent.CompleteSodaOrder(Order.Instance.GetSoda(), _pouredSoda);
    }
    
    /// <summary>
    /// Resets the canvas.
    /// </summary>
    private void ResetSodaMachineCanvas()
    {
        foreach (var button in sodaButtons)
        {
            button.GetComponent<Button>().interactable = false;
        }
        
        // todo: reset anim bools
    }
    
    /// <summary>
    /// Unsubscribes from GameEvents.
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnOrderComplete -= ResetSodaMachineCanvas;
    }
}