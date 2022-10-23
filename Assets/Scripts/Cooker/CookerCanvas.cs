using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookerCanvas : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Image grillPoint;
    
    /// <summary>
    /// The cook time sprites.
    /// </summary>
    [SerializeField] private Sprite[] cookTimeImages;

    private float[] _cookTimes = { 5f, 10f, 15f, 20f };

    private bool _placed = false;
    
    /// <summary>
    /// 
    /// </summary>
    private float _grillStartTime;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        gameObject.SetActive(false);
        grillPoint.color = new Color(1, 1, 1, 0);
    }

    void Update()
    {
        if (_placed)
        {
            grillPoint.color = Time.time - _grillStartTime switch
            {
                >= _cookTimes[0] => new Color(0.75f, 0, 0, 1),
                >= _cookTimes[1] => new Color(0.5f, 0, 0, 1),
            };
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="meat"></param>
    public void PlaceMeat(GameObject meat)
    {
        grillPoint.sprite = meat.GetComponent<SpriteRenderer>().sprite;
        grillPoint.color = new Color(1, 0, 0, 1);
        _placed = true;
        _grillStartTime = Time.time;
    }
}