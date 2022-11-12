using TMPro;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    /// <summary>
    /// The time that is allowed to pass until the level is over.
    /// </summary>
    [SerializeField] private float levelTime = 180f;

    /// <summary>
    /// The timer text.
    /// </summary>
    [SerializeField] private TextMeshProUGUI timerText;
    
    /// <summary>
    /// The time at which the level began.
    /// </summary>
    private float _startTime;

    /// <summary>
    /// The amount of time left in the level.
    /// </summary>
    private float _timeLeft;

    /// <summary>
    /// Sets the level start time.
    /// </summary>
    void Start()
    {
        _timeLeft = levelTime;
    }

    /// <summary>
    /// Checks if the level has run out of time.
    /// </summary>
    void Update()
    {
        if (_timeLeft > 0)
        {
            _timeLeft -= Time.deltaTime;

            string minutesLeft = Mathf.FloorToInt(_timeLeft / 60).ToString();
            string seconds = Mathf.FloorToInt(_timeLeft % 60).ToString();
            seconds = seconds.Length == 1 ? "0" + seconds : seconds;

            timerText.text = minutesLeft + ":" + seconds;
        }
        else
        {
            timerText.text = "0:00";
            GameEvent.CompleteLevel();
        }
    }
}