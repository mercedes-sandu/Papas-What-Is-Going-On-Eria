using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    /// <summary>
    /// The player's score.
    /// </summary>
    [SerializeField] private int score;
    
    /// <summary>
    /// The number of orders the player has completed.
    /// </summary>
    [SerializeField] private int ordersCompleted;
    
    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        GameEvent.OnScoreChange += ChangeScore;
        GameEvent.OnFoodOrderComplete += ScoreFoodOrder;
        GameEvent.OnOrderComplete += IncrementOrdersCompleted;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="amount"></param>
    private void ChangeScore(int amount)
    {
        score += amount;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="order"></param>
    private void IncrementOrdersCompleted(Order order)
    {
        ordersCompleted++;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="necessaryIngredients"></param>
    /// <param name="usedIngredients"></param>
    private void ScoreFoodOrder(Dictionary<TypeOfIngredient, GameObject> necessaryIngredients,
        List<Tuple<GameObject, TypeOfIngredient>> usedIngredients)
    {
        int decrementValue = 0;
        
        GameEvent.ChangeScore(decrementValue);
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="necessarySoda"></param>
    /// <param name="usedSoda"></param>
    /// <param name="heightDifference"></param>
    private void ScoreSodaOrder(GameObject necessarySoda, GameObject usedSoda, float heightDifference)
    {
        int decrementValue = 0;
        
        GameEvent.ChangeScore(decrementValue);
    }

    /// <summary>
    /// 
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnScoreChange -= ChangeScore;
        GameEvent.OnFoodOrderComplete -= ScoreFoodOrder;
        GameEvent.OnOrderComplete -= IncrementOrdersCompleted;
    }
}