using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Interactor : MonoBehaviour
{
    /// <summary>
    /// The transform of the player's interaction point.
    /// </summary>
    [SerializeField] private Transform _interactionPoint;
    
    /// <summary>
    /// The radius around the interaction point that will be checked for interactable objects.
    /// </summary>
    [SerializeField] private float _interactionPointRadius = 0.34f;
    
    /// <summary>
    /// The layer(s) that interactable objects are on.
    /// </summary>
    [SerializeField] private LayerMask _interactableMask;

    /// <summary>
    /// The list of interactable objects the player can access.
    /// </summary>
    private readonly BoxCollider2D[] _colliders = new BoxCollider2D[3];
    
    /// <summary>
    /// The number of interactable objects found.
    /// </summary>
    [SerializeField] private int _numFound;

    /// <summary>
    /// Consistently checks for interactable objects.
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
    /// Draws the interaction radius in the editor.
    /// </summary>
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(_interactionPoint.position, _interactionPointRadius);
    }
}
