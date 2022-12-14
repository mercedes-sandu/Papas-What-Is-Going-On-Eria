using System;
using System.Collections.Generic;
using System.Linq;
using Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        GameEvent.OnMeatCooked += ScoreMeatOrder;
        GameEvent.OnFoodOrderComplete += ScoreFoodOrder;
        GameEvent.OnSodaOrderComplete += ScoreSodaOrder;
        GameEvent.OnOrderComplete += IncrementOrdersCompleted;
        GameEvent.OnLevelComplete += CompleteLevel;

        Time.timeScale = 1;
    }

    /// <summary>
    /// Sets the level over canvas to be inactive.
    /// </summary>
    void Start()
    {
        levelOverCanvas.GetComponent<Canvas>().enabled = false;
    }

    /// <summary>
    /// Adds the specified amount to the current score. If this results in a negative score, the score is set to 0.
    /// </summary>
    /// <param name="amount">The amount to add.</param>
    private void ChangeScore(int amount)
    {
        score += amount;
        if (score < 0) score = 0;
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
    /// Scores how the meat is cooked.
    /// </summary>
    /// <param name="amount">The z-rotation of the watch hand on the cooker.</param>
    private void ScoreMeatOrder(float amount)
    {
        int requiredCookTime = Order.Instance.GetCookTime();
        int cookedTime = (int)(360 - amount) / 90 + 1;
        GameEvent.ChangeScore(Math.Abs(cookedTime - requiredCookTime) * -5);
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

        // Check if the correct types of ingredients were used.
        decrementValue = necessaryIngredients.Keys.Where(type => usedIngredients
                .FindIndex(x => x.Item2 == type) == -1)
            .Aggregate(0, (current, type) => current - 10);

        // Check if the correct ingredients were used.
        decrementValue = usedIngredients.Where(ingredient => necessaryIngredients.Keys
                                                                 .Contains(ingredient.Item2) &&
                                                             !ReferenceEquals(necessaryIngredients[ingredient.Item2],
                                                                 ingredient.Item1))
            .Aggregate(decrementValue, (current, ingredient) => current - 10);

        // Check if the ingredients were placed at the correct positions.
        decrementValue = xDistances.Aggregate(decrementValue, (current, distance) => current - (int)distance);

        // Change the score.
        GameEvent.ChangeScore(decrementValue);
    }

    /// <summary>
    /// Scores the soda order according to accuracy of soda chosen.
    /// </summary>
    /// <param name="necessarySoda">The necessary soda for this order.</param>
    /// <param name="usedSoda">The used soda for this order.</param>
    private void ScoreSodaOrder(GameObject necessarySoda, GameObject usedSoda)
    {
        if (!ReferenceEquals(necessarySoda, usedSoda))
        {
            GameEvent.ChangeScore(-10);
        }
    }

    /// <summary>
    /// Restarts the level.
    /// </summary>
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Updates the level over UI and pauses the game.
    /// </summary>
    private void CompleteLevel()
    {
        scoreText.text = "Score: " + score;
        levelOverCanvas.GetComponent<Canvas>().enabled = true;
        Time.timeScale = 0;
    }

    /// <summary>
    /// Unsubscribes from GameEvents.
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnScoreChange -= ChangeScore;
        GameEvent.OnMeatCooked -= ScoreMeatOrder;
        GameEvent.OnFoodOrderComplete -= ScoreFoodOrder;
        GameEvent.OnSodaOrderComplete -= ScoreSodaOrder;
        GameEvent.OnOrderComplete -= IncrementOrdersCompleted;
        GameEvent.OnLevelComplete -= CompleteLevel;
    }
}