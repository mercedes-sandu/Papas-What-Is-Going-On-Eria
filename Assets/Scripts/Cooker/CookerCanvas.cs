using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CookerCanvas : MonoBehaviour
{
    /// <summary>
    /// An instance of the cooker UI canvas that is accessible by all classes.
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
    /// The displayed cooking time.
    /// </summary>
    [SerializeField] private Image cookTimeImage;
    
    /// <summary>
    /// The watch hand object.
    /// </summary>
    [SerializeField] private GameObject watchHand;
    
    /// <summary>
    /// The meat that has been cooked.
    /// </summary>
    [SerializeField] private GameObject cookedMeat;

    /// <summary>
    /// The color at which the meat has been cooked.
    /// </summary>
    [SerializeField] private Color cookedColor;

    /// <summary>
    /// The name of the meat that has been cooked.
    /// </summary>
    [SerializeField] private string cookedMeatName;

    /// <summary>
    /// The list of color filters that change the appearance of the cooking meat.
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
    /// True if the object has been placed, false otherwise.
    /// </summary>
    private bool _placed = false;

    /// <summary>
    /// True if the cooked meat has been clicked, false otherwise.
    /// </summary>
    private bool _meatClicked = false;
    
    /// <summary>
    /// The time that the object has been placed.
    /// </summary>
    private float _grillStartTime;

    /// <summary>
    /// Initializes components and variables, subscribes to GameEvents.
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

        GameEvent.OnOrderComplete += ResetCookerCanvas;
    }
    
    /// <summary>
    /// Sets the UI canvas to be inactive.
    /// </summary>
    void Start()
    {
        grillPoint.color = new Color(1, 1, 1, 0);
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Updates the state of the cooking meat and checks to close the canvas.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseCanvas();
        }
        
        if (_placed && !_meatClicked)
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
    /// Places the meat object specified on the grill.
    /// </summary>
    /// <param name="meat">The meat.</param>
    public void PlaceMeat(GameObject meat)
    {
        grillPoint.sprite = meat.GetComponent<SpriteRenderer>().sprite;
        grillPoint.color = new Color(1, 0, 0, 1);
        cookedMeatName = meat.name;
        _placed = true;
        _grillStartTime = Time.time;
    }

    /// <summary>
    /// Called when the meat is clicked.
    /// </summary>
    public void OnMeatClick()
    {
        _meatClicked = true;
        cookedColor = grillPoint.color;
        cookedMeat = grillPoint.gameObject;
        grillPoint.color = new Color(1, 1, 1, 0);
        GameEvent.CompleteMeatCooking(watchHand.transform.eulerAngles.z);
        Destroy(cookedMeat.GetComponent<EventTrigger>());
    }
    
    /// <summary>
    /// Returns the cooked meat image.
    /// </summary>
    /// <returns>Cooked meat image.</returns>
    public GameObject GetCookedMeat() => cookedMeat;
    
    /// <summary>
    /// Returns the cooked meat color.
    /// </summary>
    /// <returns>Cooked meat color.</returns>
    public Color GetCookedColor() => cookedColor;

    /// <summary>
    /// Returns the cooked meat name.
    /// </summary>
    /// <returns>Name.</returns>
    public string GetCookedMeatName() => cookedMeatName;

    /// <summary>
    /// Closes the cooker canvas.
    /// </summary>
    public void CloseCanvas()
    {
        gameObject.SetActive(false);
    }

    /// <summary>
    /// 
    /// </summary>
    private void ResetCookerCanvas()
    {
        grillPoint.sprite = null;
        // todo: do i need to reset rotation of watch hand and color of grillpoint?
    }

    /// <summary>
    /// 
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnOrderComplete -= ResetCookerCanvas;
    }
}