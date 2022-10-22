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
    /// Detects when the score needs to be changed.
    /// </summary>
    public static event ScoreHandler OnScoreChange;
    
    /// <summary>
    /// Changes the score by adding the specified modifier.
    /// </summary>
    /// <param name="score">The amount to modify the score by.</param>
    public static void ChangeScore(int score) => OnScoreChange?.Invoke(score);
}