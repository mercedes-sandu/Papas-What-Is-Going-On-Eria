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
    /// Initializes necessary components and sets the canvas to be inactive.
    /// </summary>
    void Start()
    {
        _centerX = plate.transform.position.x; // TODO: check if this is actually correct
        ghostObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        gameObject.SetActive(false);
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

        ghostObject.GetComponent<Image>().color = _placingObject ? new Color(1, 1, 1, 0.5f) 
            : new Color(1, 1, 1, 0);

        ghostObject.transform.position = Input.mousePosition;

        if (_placingObject && Input.GetMouseButtonDown(0))
        {
            _placingObject = false;
            var placedObject = Instantiate(ghostObject, ghostObject.transform.position, Quaternion.identity,
                plate.transform);
            placedObject.name = _nameOfPlacedObject;
            placedObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
            assembler.AddItem(placedObject, _currentIngredientType);
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
        }
    }

    /// <summary>
    /// Creates a semi-transparent item that will follow the cursor.
    /// </summary>
    /// <param name="item">The item to be created.</param>
    public void CreateItem(GameObject item)
    {
        ghostObject.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        ghostObject.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        _nameOfPlacedObject = item.name;
        _currentIngredientType = item.GetComponent<Ingredient>().GetTypeOfIngredient();
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
