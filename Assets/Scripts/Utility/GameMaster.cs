using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    /// <summary>
    /// The time that is allowed to pass until the level is over.
    /// </summary>
    [SerializeField] private float levelTime = 300f;

    /// <summary>
    /// The time at which the level began.
    /// </summary>
    private float _startTime;

    /// <summary>
    /// Sets the level start time.
    /// </summary>
    void Start()
    {
        _startTime = Time.time;
    }

    /// <summary>
    /// Checks if the level has run out of time.
    /// </summary>
    void Update()
    {
        if (Time.time - _startTime >= levelTime)
        {
            // TODO: trigger game over
            // todo: do this with a coroutine if possible
        }
    }
}