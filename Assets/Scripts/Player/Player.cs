using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The player's score.
    /// </summary>
    [SerializeField] private int score;

    /// <summary>
    /// Gets or sets the player's score.
    /// </summary>
    public int Score
    {
        get => score;
        set => score = value;
    }
}
