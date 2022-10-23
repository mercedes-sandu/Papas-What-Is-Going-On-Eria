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
    [SerializeField] private float _levelTime;
    
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
}
