using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    /// <summary>
    /// An instance of the game master that is accessible by all classes.
    /// </summary>
    public static GameMaster Instance = null;

    /// <summary>
    /// The time that is allowed to pass until the level is over.
    /// </summary>
    [SerializeField] private float levelTime = 300f;
    
    /// <summary>
    /// The player's score.
    /// </summary>
    [SerializeField] private int score;

    /// <summary>
    /// The number of orders the player has completed.
    /// </summary>
    [SerializeField] private int ordersCompleted;

    /// <summary>
    /// The time at which the level began.
    /// </summary>
    private float _startTime;

    /// <summary>
    /// Initializes components and variables.
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

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        _startTime = Time.time;
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (Time.time - _startTime >= levelTime)
        {
            // TODO: trigger game over
        }
    }

    /// <summary>
    /// Returns the player's current score.
    /// </summary>
    /// <returns>The player's score.</returns>
    public int GetScore() => score;
    
    /// <summary>
    /// Adds the specified amount to the player's score.
    /// </summary>
    /// <param name="amount">The amount to add.</param>
    public void AddToScore(int amount) => score += amount;
    
    /// <summary>
    /// Returns the number of orders the player has completed.
    /// </summary>
    /// <returns>The number of orders.</returns>
    public int GetNumberOrdersCompleted() => ordersCompleted;
    
    /// <summary>
    /// Increments the number of orders the player has completed.
    /// </summary>
    public void IncrementOrdersCompleted() => ordersCompleted++;
}
