using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using TMPro;
using UnityEngine;

public class ScoringSystem : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject levelOverCanvas;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private TextMeshProUGUI scoreText;

    /// <summary>
    /// 
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
    /// 
    /// </summary>
    void Awake()
    {
        GameEvent.OnScoreChange += ChangeScore;
        GameEvent.OnFoodOrderComplete += ScoreFoodOrder;
        GameEvent.OnSodaOrderComplete += ScoreSodaOrder;
        GameEvent.OnOrderComplete += IncrementOrdersCompleted;
        GameEvent.OnLevelComplete += CompleteLevel;
    }

    void Start()
    {
        levelOverCanvas.SetActive(false);
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
    private void IncrementOrdersCompleted()
    {
        ordersCompleted++;
        ordersCompletedText.text = "Orders Completed: " + ordersCompleted;
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
    private void CompleteLevel()
    {
        scoreText.text = "Score: " + score;
        levelOverCanvas.SetActive(true);
    }

    /// <summary>
    /// 
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