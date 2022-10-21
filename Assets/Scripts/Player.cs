using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// <summary>
    /// The player's score.
    /// </summary>
    private int _score;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    /// <summary>
    /// Gets or sets the player's score.
    /// </summary>
    public int Score
    {
        get => _score;
        set => _score = value;
    }
}
