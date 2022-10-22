using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    /// <summary>
    /// The type of ingredient.
    /// </summary>
    [SerializeField] private TypeOfIngredient _ingredient;
    
    /// <summary>
    /// True if the ingredient can be used, false otherwise.
    /// </summary>
    [SerializeField] private bool _canUse = true;

    /// <summary>
    /// Returns whether the ingredient can be used.
    /// </summary>
    /// <returns>True if the ingredient can be used, false otherwise.</returns>
    public bool CanUse() => _canUse;
}