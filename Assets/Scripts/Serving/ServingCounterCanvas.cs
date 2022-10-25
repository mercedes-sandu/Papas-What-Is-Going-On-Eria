using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServingCounterCanvas : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    private Animator _animator;
    
    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        GameEvent.OnOrderComplete += AnimateCanvas;
    }
    
    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        _animator = GetComponent<Animator>();
        _animator.SetBool("IsPopping", false);
    }
    
    /// <summary>
    /// 
    /// </summary>
    private void AnimateCanvas()
    {
        _animator.SetBool("IsPopping", true);
    }
    
    /// <summary>
    /// 
    /// </summary>
    public void StopAnimateCanvas()
    {
        _animator.SetBool("IsPopping", false);
    }
    
    /// <summary>
    /// 
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnOrderComplete -= AnimateCanvas;
    }
}
