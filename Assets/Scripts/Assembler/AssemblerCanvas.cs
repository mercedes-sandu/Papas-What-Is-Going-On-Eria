using System.Collections;
using System.Collections.Generic;
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
    /// The table (background).
    /// </summary>
    [SerializeField] private GameObject table;

    /// <summary>
    /// The center x-position of the plate.
    /// </summary>
    private float _centerX;

    /// <summary>
    /// True if the player is currently placing an object, false otherwise.
    /// </summary>
    private bool _placingObject = false;

    /// <summary>
    /// The currently held game object.
    /// </summary>
    private GameObject _currentHeldObject;

    /// <summary>
    /// Initializes necessary components and sets the canvas to be inactive.
    /// </summary>
    void Start()
    {
        _centerX = plate.transform.position.x; // TODO: check if this is actually correct
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Listens for a mouse click to place the currently held object.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseCanvas();
        }
        
        if (_placingObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FollowAndPlace.PlaceObject(_currentHeldObject, plate);
                assembler.AddItem(_currentHeldObject);
                Debug.Log("Placed object: " + _currentHeldObject.name);
                _currentHeldObject = null;
                Debug.Log("Current held object: " + _currentHeldObject);
                _placingObject = false;
            }
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
        }
    }

    /// <summary>
    /// Creates a semi-transparent item that will follow the cursor.
    /// </summary>
    /// <param name="item">The item to be created.</param>
    public void CreateItem(GameObject item)
    {
        var newItem = new GameObject(item.name, typeof(RectTransform), typeof(Image), 
            typeof(FollowAndPlace));
        newItem.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 500);
        newItem.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        newItem.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        Instantiate(newItem, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity, 
            table.transform);
        _currentHeldObject = newItem;
        Debug.Log("Current held object: " + _currentHeldObject);
        _placingObject = true;
    }

    /// <summary>
    /// Completes the food order to be scored.
    /// </summary>
    public void CompleteFoodOrder()
    {
        Order.CompleteOrder(assembler.GetStackedItems());
    }

    /// <summary>
    /// Closes the assembler canvas.
    /// </summary>
    public void CloseCanvas()
    {
        gameObject.SetActive(false);
    }
}
