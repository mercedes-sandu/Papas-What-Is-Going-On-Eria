using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingCounterCanvas : MonoBehaviour
{
    /// <summary>
    /// The animator for the serving counter canvas.
    /// </summary>
    private Animator _animator;
    
    /// <summary>
    /// The canvas component.
    /// </summary>
    private Canvas _canvas;
    
    /// <summary>
    /// Subscribes to GameEvents.
    /// </summary>
    void Awake()
    {
        GameEvent.OnOrderComplete += AnimateCanvas;
    }
    
    /// <summary>
    /// Sets animator component and variable.
    /// </summary>
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsPopping", false);
        _canvas.enabled = false;
    }
    
    /// <summary>
    /// Animates the canvas.
    /// </summary>
    private void AnimateCanvas()
    {
        _canvas.enabled = true;
        _animator.SetBool("IsPopping", true);
    }
    
    /// <summary>
    /// Stops animating the canvas.
    /// </summary>
    public void StopAnimateCanvas()
    {
        _animator.SetBool("IsPopping", false);
        _canvas.enabled = false;
    }
    
    /// <summary>
    /// Unsubscribes from GameEvents.
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnOrderComplete -= AnimateCanvas;
    }
}