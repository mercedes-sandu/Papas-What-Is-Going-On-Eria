using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public static class GameEvent
{
    /// <summary>
    /// Handles the player's score.
    /// </summary>
    public delegate void ScoreHandler(int amount);

    /// <summary>
    /// 
    /// </summary>
    public delegate void FoodHandler(Dictionary<TypeOfIngredient, GameObject> necessaryIngredients,
        List<Tuple<GameObject, TypeOfIngredient>> usedIngredients);

    /// <summary>
    /// 
    /// </summary>
    public delegate void SodaHandler(GameObject necessarySoda, GameObject usedSoda, float heightDifference);
    
    /// <summary>
    /// Handles the player's current order.
    /// </summary>
    public delegate void OrderHandler(Order order);

    /// <summary>
    /// Detects when the score needs to be changed.
    /// </summary>
    public static event ScoreHandler OnScoreChange;

    /// <summary>
    /// Detects when the food order has been completed.
    /// </summary>
    public static event FoodHandler OnFoodOrderComplete;
    
    /// <summary>
    /// Detects when the soda order has been completed.
    /// </summary>
    public static event SodaHandler OnSodaOrderComplete;
    
    /// <summary>
    /// Detects when the current order has been completed.
    /// </summary>
    public static event OrderHandler OnOrderComplete;
    
    /// <summary>
    /// Changes the score by adding the specified modifier.
    /// </summary>
    /// <param name="amount">The amount to modify the score by.</param>
    public static void ChangeScore(int amount) => OnScoreChange?.Invoke(amount);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="necessaryIngredients"></param>
    /// <param name="usedIngredients"></param>
    public static void CompleteFoodOrder(Dictionary<TypeOfIngredient, GameObject> necessaryIngredients,
        List<Tuple<GameObject, TypeOfIngredient>> usedIngredients) => 
        OnFoodOrderComplete?.Invoke(necessaryIngredients, usedIngredients);
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="necessarySoda"></param>
    /// <param name="usedSoda"></param>
    /// <param name="heightDifference"></param>
    public static void CompleteSodaOrder(GameObject necessarySoda, GameObject usedSoda, float heightDifference) => 
        OnSodaOrderComplete?.Invoke(necessarySoda, usedSoda, heightDifference);
    
    /// <summary>
    /// Completes the current order.
    /// </summary>
    /// <param name="order">The current order.</param>
    public static void CompleteOrder(Order order) => OnOrderComplete?.Invoke(order);
}