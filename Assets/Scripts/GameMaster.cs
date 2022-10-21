using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    /// <summary>
    /// An instance of the game master that is accessible by all classes.
    /// </summary>
    public static GameMaster Instance = null;

    [SerializeField] private float _levelTime;
    
    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }
}
