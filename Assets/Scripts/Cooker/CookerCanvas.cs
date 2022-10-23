using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CookerCanvas : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    public static CookerCanvas Instance = null;
    
    /// <summary>
    /// The grill area.
    /// </summary>
    [SerializeField] private Image grillPoint;
    
    /// <summary>
    /// The cook time sprites.
    /// </summary>
    [SerializeField] private Sprite[] cookTimeImages;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Image cookTimeImage;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject watchHand;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Image cookedMeat;

    /// <summary>
    /// 
    /// </summary>
    private readonly Color32[] _grillColors =
    {
        new Color32(255, 0, 0, 255), 
        new Color32(255, 85, 85, 255), 
        new Color32(255, 170, 170, 255),
        new Color32(255, 255, 255, 255), 
        new Color32(0, 0, 0, 255)
    };

    /// <summary>
    /// 
    /// </summary>
    private bool _placed = false;
    
    /// <summary>
    /// 
    /// </summary>
    private float _grillStartTime;

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
        gameObject.SetActive(false);
        grillPoint.color = new Color(1, 1, 1, 0);
    }

    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameObject.SetActive(false);
        }
        
        if (_placed)
        {
            // Gradually change the color of the meat.
            grillPoint.color = Color.Lerp(_grillColors[0], _grillColors[3],
                (Time.time - _grillStartTime) / 20f);
            if (Time.time - _grillStartTime > 20f)
            {
                grillPoint.color = _grillColors[4];
            }
            
            // Change the cook time image.
            cookTimeImage.sprite = (Time.time - _grillStartTime) switch
            {
                >= 0f and < 5f => cookTimeImages[0],
                >= 5f and < 10f => cookTimeImages[1],
                >= 10f and < 15f => cookTimeImages[2],
                >= 15f => cookTimeImages[3],
                _ => null
            };
            
            // Gradually rotate the watch hand.
            watchHand.transform.rotation = Quaternion.Euler(0, 0, 
                Mathf.Lerp(0, -360, (Time.time - _grillStartTime) / 20f));
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

    /// <summary>
    /// 
    /// </summary>
    public void OnMeatClick()
    {
        cookedMeat.sprite = grillPoint.sprite;
        cookedMeat.color = grillPoint.color;
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    public Image GetCookedMeat() => cookedMeat;
}