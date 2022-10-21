using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameEvent
{
    public delegate void ScoreHandler(int score);

    public static event ScoreHandler OnScoreChange;
    
    public static void ChangeScore(int score) => OnScoreChange?.Invoke(score);
}