using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    /// <summary>
    /// The level over canvas.
    /// </summary>
    [SerializeField] private GameObject levelOverCanvas;
    
    /// <summary>
    /// The score text.
    /// </summary>
    [SerializeField] private TextMeshProUGUI scoreText;

    /// <summary>
    /// The orders completed text.
    /// </summary>
    [SerializeField] private TextMeshProUGUI ordersCompletedText;
    
    /// <summary>
    /// The player's score.
    /// </summary>
    [SerializeField] private int score;
    
    /// <summary>
    /// The number of orders the player has completed.
    /// </summary>
    [SerializeField] private int ordersCompleted;
    
    /// <summary>
    /// Subscribes to GameEvents.
    /// </summary>
    void Awake()
    {
        GameEvent.OnScoreChange += ChangeScore;
        GameEvent.OnFoodOrderComplete += ScoreFoodOrder;
        GameEvent.OnSodaOrderComplete += ScoreSodaOrder;
        GameEvent.OnOrderComplete += IncrementOrdersCompleted;
        GameEvent.OnLevelComplete += CompleteLevel;
    }

    /// <summary>
    /// Sets the level over canvas to be inactive.
    /// </summary>
    void Start()
    {
        levelOverCanvas.SetActive(false);
    }

    /// <summary>
    /// Adds the specified amount to the current score.
    /// </summary>
    /// <param name="amount">The amount to add.</param>
    private void ChangeScore(int amount)
    {
        score += amount;
    }
    
    /// <summary>
    /// Increments the number of orders completed by 1.
    /// </summary>
    private void IncrementOrdersCompleted()
    {
        ordersCompleted++;
        ordersCompletedText.text = "Orders Completed: " + ordersCompleted;
    }

    /// <summary>
    /// Scores the food order according to accuracy of ingredients and position of ingredients.
    /// </summary>
    /// <param name="necessaryIngredients">The necessary ingredients for this order.</param>
    /// <param name="usedIngredients">The used ingredients for this order.</param>
    /// <param name="xDistances">The differences in x-positions of the ingredients.</param>
    private void ScoreFoodOrder(Dictionary<TypeOfIngredient, GameObject> necessaryIngredients,
        List<Tuple<GameObject, TypeOfIngredient>> usedIngredients, List<float> xDistances)
    {
        int decrementValue = 0;
        
        GameEvent.ChangeScore(decrementValue);
    }
    
    /// <summary>
    /// Scores the soda order according to accuracy of soda chosen and height difference from the fill line.
    /// </summary>
    /// <param name="necessarySoda">The necessary soda for this order.</param>
    /// <param name="usedSoda">The used soda for this order.</param>
    /// <param name="heightDifference">The difference in y-position from the fill line.</param>
    private void ScoreSodaOrder(GameObject necessarySoda, GameObject usedSoda, float heightDifference)
    {
        int decrementValue = 0;
        
        GameEvent.ChangeScore(decrementValue);
    }

    /// <summary>
    /// Updates the level over UI and pauses the game.
    /// </summary>
    private void CompleteLevel()
    {
        scoreText.text = "Score: " + score;
        levelOverCanvas.SetActive(true);
        Time.timeScale = 0;
    }

    /// <summary>
    /// Unsubscribes from GameEvents.
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnScoreChange -= ChangeScore;
        GameEvent.OnFoodOrderComplete -= ScoreFoodOrder;
        GameEvent.OnSodaOrderComplete -= ScoreSodaOrder;
        GameEvent.OnOrderComplete -= IncrementOrdersCompleted;
        GameEvent.OnLevelComplete -= CompleteLevel;
    }
}