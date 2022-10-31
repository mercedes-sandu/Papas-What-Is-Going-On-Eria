using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AssemblerCanvas : MonoBehaviour
{
    /// <summary>
    /// The assembler in the scene.
    /// </summary>
    [SerializeField] private Assembler assembler;
    
    /// <summary>
    /// The cooked meat from the cooker.
    /// </summary>
    [SerializeField] private GameObject cookedMeat;
    
    /// <summary>
    /// The plate onto which the burger will be assembled.
    /// </summary>
    [SerializeField] private GameObject plate;

    /// <summary>
    /// The ghost object which follows the player's cursor.
    /// </summary>
    [SerializeField] private GameObject ghostObject;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject garbageCan;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Sprite closedGarbage;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Sprite openGarbage;
    
    /// <summary>
    /// The list of currently stacked items in the assembler canvas.
    /// </summary>
    [SerializeField] private List<Tuple<GameObject, TypeOfIngredient>> _stackedItems
        = new List<Tuple<GameObject, TypeOfIngredient>>();

    /// <summary>
    /// The list of differences in the x-positions of the stacked items from the center value.
    /// </summary>
    [SerializeField] private List<float> xDistances;

    /// <summary>
    /// The center x-position of the plate.
    /// </summary>
    private float _centerX;

    /// <summary>
    /// True if the player is currently placing an object, false otherwise.
    /// </summary>
    private bool _placingObject = false;

    /// <summary>
    /// The name of the object that was placed.
    /// </summary>
    private string _nameOfPlacedObject = "";

    /// <summary>
    /// The type of the currently held ingredient.
    /// </summary>
    private TypeOfIngredient _currentIngredientType = TypeOfIngredient.None;

    /// <summary>
    /// The color of the meat.
    /// </summary>
    private Color _meatColor;
    
    /// <summary>
    /// True if the player is currently holding meat, false otherwise.
    /// </summary>
    private bool _isHoldingMeat = false;

    /// <summary>
    /// 
    /// </summary>
    private bool _isThrowingAway = false;
    
    /// <summary>
    /// The canvas component.
    /// </summary>
    private Canvas _canvas;

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        GameEvent.OnOrderComplete += ResetAssemblerCanvas;
    }
    
    /// <summary>
    /// Initializes necessary components and sets the canvas to be inactive.
    /// </summary>
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        _centerX = plate.transform.position.x; // TODO: check if this is actually correct
        ghostObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        cookedMeat.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        _canvas.enabled = false;
    }

    /// <summary>
    /// Moves the ghost object to the mouse pointer and listens for a mouse click to place the currently held object.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseCanvas();
        }

        if (_isHoldingMeat)
        {
            ghostObject.GetComponent<Image>().color = new Color(_meatColor.r, _meatColor.g, _meatColor.b, 0.5f);
        }
        else
        {
            ghostObject.GetComponent<Image>().color = _placingObject ? new Color(1, 1, 1, 0.5f) 
                : new Color(1, 1, 1, 0);
        }
        
        ghostObject.transform.position = Input.mousePosition;

        if (_placingObject && !_isThrowingAway && Input.GetMouseButtonDown(0))
        {
            _placingObject = false;
            var placedObject = Instantiate(ghostObject, ghostObject.transform.position, Quaternion.identity,
                plate.transform);
            placedObject.name = _nameOfPlacedObject;
            
            if (_isHoldingMeat)
            {
                placedObject.GetComponent<Image>().color = _meatColor;
                _isHoldingMeat = false;
            }
            else
            {
                placedObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            }
            
            _stackedItems.Add(new Tuple<GameObject, TypeOfIngredient>(placedObject, _currentIngredientType));
            // todo: calculate xDistances and add to list
            _currentIngredientType = TypeOfIngredient.None;
        }
    }

    /// <summary>
    /// Sets the cooked meat to the one from the cooker.
    /// </summary>
    public void AcquireMeat()
    {
        var meat = CookerCanvas.Instance.GetCookedMeat();
        if (meat != null)
        {
            Destroy(cookedMeat.GetComponent<EventTrigger>());
            cookedMeat.GetComponent<Image>().sprite = CookerCanvas.Instance.GetCookedMeat().GetComponent<Image>().sprite;
            cookedMeat.GetComponent<Image>().color = CookerCanvas.Instance.GetCookedColor();
            _meatColor = CookerCanvas.Instance.GetCookedColor();
        }
    }

    /// <summary>
    /// Creates a semi-transparent meat item that will follow the cursor.
    /// </summary>
    public void CreateMeat()
    {
        var meat = CookerCanvas.Instance.GetCookedMeat();
        meat.AddComponent<Ingredient>();
        meat.GetComponent<Ingredient>().SetTypeOfIngredient(TypeOfIngredient.Meat);
        meat.name = CookerCanvas.Instance.GetCookedMeatName();
        cookedMeat.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        CreateItem(meat);
    }
    
    /// <summary>
    /// Creates a semi-transparent item that will follow the cursor.
    /// </summary>
    /// <param name="item">The item to be created.</param>
    public void CreateItem(GameObject item)
    {
        ghostObject.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>() != null 
            ? item.GetComponent<SpriteRenderer>().sprite : item.GetComponent<Image>().sprite;

        if (item.GetComponent<Ingredient>().GetTypeOfIngredient().Equals(TypeOfIngredient.Meat))
        {
            _isHoldingMeat = true;
            ghostObject.GetComponent<Image>().color = new Color(_meatColor.r, _meatColor.g, _meatColor.b, 0.5f);
        }
        else
        {
            ghostObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        }
        
        _nameOfPlacedObject = item.name;
        _currentIngredientType = item.GetComponent<Ingredient>().GetTypeOfIngredient();
        _placingObject = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void HoverGarbageCan()
    {
        _isThrowingAway = true;
        garbageCan.GetComponent<Image>().sprite = openGarbage;
    }

    /// <summary>
    /// 
    /// </summary>
    public void StopHoveringGarbageCan()
    {
        _isThrowingAway = false;
        garbageCan.GetComponent<Image>().sprite = closedGarbage;
    }

    /// <summary>
    /// 
    /// </summary>
    public void TrashItem()
    {
        _placingObject = false;
        _currentIngredientType = TypeOfIngredient.None;
    }

    /// <summary>
    /// Completes the food order to be scored.
    /// </summary>
    public void CompleteFoodOrder()
    {
        foreach (Transform child in plate.transform)
        {
            child.gameObject.GetComponent<Image>().enabled = false;
        }
        GameEvent.CompleteFoodOrder(Order.Instance.GetIngredientsDict(), _stackedItems, xDistances);
    }

    /// <summary>
    /// 
    /// </summary>
    private void ResetAssemblerCanvas()
    {
        foreach (Transform child in plate.transform)
        {
            Destroy(child.gameObject);
        }
    }

    /// <summary>
    /// Closes the assembler canvas.
    /// </summary>
    public void CloseCanvas()
    {
        _canvas.enabled = false;
    }

    /// <summary>
    /// 
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnOrderComplete -= ResetAssemblerCanvas;
    }
}