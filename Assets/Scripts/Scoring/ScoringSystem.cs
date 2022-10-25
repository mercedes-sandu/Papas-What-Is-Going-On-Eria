using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public static ScoringSystem Instance = null;

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    public void ScoreFoodOrder(Dictionary<TypeOfIngredient, GameObject> necessaryIngredients,
        List<Tuple<GameObject, TypeOfIngredient>> usedIngredients)
    {
        
    }
}