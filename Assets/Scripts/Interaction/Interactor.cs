using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Interactor : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Transform _interactionPoint;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private float _interactionPointRadius = 0.34f;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private LayerMask _interactableMask;

    /// <summary>
    /// 
    /// </summary>
    private readonly BoxCollider2D[] _colliders = new BoxCollider2D[3];
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private int _numFound;

    /// <summary>
    /// 
    /// </summary>
    void FixedUpdate()
    {
        _numFound = Physics2D.OverlapCircleNonAlloc(_interactionPoint.position, _interactionPointRadius, 
            _colliders, _interactableMask);

        if (_numFound > 0)
        {
            var interactable = _colliders[0].GetComponent<IInteractable>();
            if (interactable != null && Input.GetKeyDown(KeyCode.E))
            {
                interactable.Interact(this);
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
