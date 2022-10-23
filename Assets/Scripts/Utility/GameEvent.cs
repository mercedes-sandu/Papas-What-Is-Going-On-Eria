using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvent
{
    /// <summary>
    /// Handles the player's score.
    /// </summary>
    public delegate void ScoreHandler(int score);

    /// <summary>
    /// Handles the player's current order.
    /// </summary>
    public delegate void OrderHandler(Order order);

    /// <summary>
    /// Detects when the score needs to be changed.
    /// </summary>
    public static event ScoreHandler OnScoreChange;

    /// <summary>
    /// Detects when the current order has been completed.
    /// </summary>
    public static event OrderHandler OnOrderComplete;
    
    /// <summary>
    /// Changes the score by adding the specified modifier.
    /// </summary>
    /// <param name="score">The amount to modify the score by.</param>
    public static void ChangeScore(int score) => OnScoreChange?.Invoke(score);
    
    /// <summary>
    /// Completes the current order.
    /// </summary>
    /// <param name="order">The current order.</param>
    public static void CompleteOrder(Order order) => OnOrderComplete?.Invoke(order);
}