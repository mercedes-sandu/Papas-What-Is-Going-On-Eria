using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private TypeOfIngredient _ingredient;
    [SerializeField] private bool _canUse = true;
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    public bool CanUse() => _canUse;
}
