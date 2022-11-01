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
    /// Handles the meat on the grill.
    /// </summary>
    public delegate void GrillHandler(float amount);
    
    /// <summary>
    /// Handles the player's food order.
    /// </summary>
    public delegate void FoodHandler(Dictionary<TypeOfIngredient, GameObject> necessaryIngredients,
        List<Tuple<GameObject, TypeOfIngredient>> usedIngredients, List<float> xDistances);

    /// <summary>
    /// Handles the player's soda order.
    /// </summary>
    public delegate void SodaHandler(GameObject necessarySoda, GameObject usedSoda);
    
    /// <summary>
    /// Handles the player's current order.
    /// </summary>
    public delegate void OrderHandler();

    /// <summary>
    /// Handles the level.
    /// </summary>
    public delegate void LevelHandler();

    /// <summary>
    /// Detects when the score needs to be changed.
    /// </summary>
    public static event ScoreHandler OnScoreChange;

    /// <summary>
    /// Detects when the meat on the grill is done being cooked.
    /// </summary>
    public static event GrillHandler OnMeatCooked;
    
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
    /// Detects when the level has been completed.
    /// </summary>
    public static event LevelHandler OnLevelComplete;
    
    /// <summary>
    /// Changes the score by adding the specified modifier.
    /// </summary>
    /// <param name="amount">The amount to modify the score by.</param>
    public static void ChangeScore(int amount) => OnScoreChange?.Invoke(amount);

    /// <summary>
    /// Completes the meat order.
    /// </summary>
    /// <param name="amount">The amount the meat has been cooked.</param>
    public static void CompleteMeatCooking(float amount) => OnMeatCooked?.Invoke(amount);
    
    /// <summary>
    /// Completes the food order.
    /// </summary>
    /// <param name="necessaryIngredients">The necessary ingredients for the order.</param>
    /// <param name="usedIngredients">The ingredients used for this order.</param>
    /// <param name="xDistances">The differences in x-positions of the stacked ingredients from the center.</param>
    public static void CompleteFoodOrder(Dictionary<TypeOfIngredient, GameObject> necessaryIngredients,
        List<Tuple<GameObject, TypeOfIngredient>> usedIngredients, List<float> xDistances) => 
        OnFoodOrderComplete?.Invoke(necessaryIngredients, usedIngredients, xDistances);
    
    /// <summary>
    /// Completes the soda order.
    /// </summary>
    /// <param name="necessarySoda">The necessary soda for this order.</param>
    /// <param name="usedSoda">The soda used for this order.</param>
    public static void CompleteSodaOrder(GameObject necessarySoda, GameObject usedSoda) => 
        OnSodaOrderComplete?.Invoke(necessarySoda, usedSoda);
    
    /// <summary>
    /// Completes the current order.
    /// </summary>
    public static void CompleteOrder() => OnOrderComplete?.Invoke();
    
    /// <summary>
    /// Completes the current level.
    /// </summary>
    public static void CompleteLevel() => OnLevelComplete?.Invoke();
}