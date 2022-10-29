using System;
using System.Collections;
using System.Collections.Generic;
using Scripts;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OrderCanvas : MonoBehaviour
{
    /// <summary>
    /// The ingredients text objects.
    /// </summary>
    [SerializeField] private TextMeshProUGUI[] ingredientsTexts;
    
    /// <summary>
    /// The ingredients images.
    /// </summary>
    [SerializeField] private Image[] ingredientsImages;

    /// <summary>
    /// The cook time sprites.
    /// </summary>
    [SerializeField] private Sprite[] cookTimeImages;
    
    /// <summary>
    /// The cook time sprite for this order.
    /// </summary>
    [SerializeField] private Image cookTimeImage;

    /// <summary>
    /// The soda.
    /// </summary>
    [SerializeField] private Image sodaImage;
    
    /// <summary>
    /// The dictionary of ingredients mapped to their text objects.
    /// </summary>
    private Dictionary<TypeOfIngredient, TextMeshProUGUI> _textMeshes =
        new Dictionary<TypeOfIngredient, TextMeshProUGUI>();
    
    /// <summary>
    /// The dictionary of ingredients mapped to their images.
    /// </summary>
    private Dictionary<TypeOfIngredient, Image> _images = new Dictionary<TypeOfIngredient, Image>();

    /// <summary>
    /// To be appended to text if there is no ingredient for a particular ingredient type.
    /// </summary>
    private const string NullObjectString = "        ???";
    // TODO: change this to say [redacted] or something

    /// <summary>
    /// The canvas component.
    /// </summary>
    private Canvas _canvas;

    /// <summary>
    /// 
    /// </summary>
    void Awake()
    {
        GameEvent.OnOrderComplete += ResetOrderCanvas;
    }

    /// <summary>
    /// Sets the canvas to be inactive initially.
    /// </summary>
    void Start()
    {
        _canvas = GetComponent<Canvas>();
        
        int counter = 0;
        foreach (TypeOfIngredient type in TypeOfIngredient.GetValues(typeof(TypeOfIngredient)))
        {
            if (!type.Equals(TypeOfIngredient.None) && !type.Equals(TypeOfIngredient.Soda))
            {
                _textMeshes.Add(type, ingredientsTexts[counter]);
                _images.Add(type, ingredientsImages[counter]);
                counter++;
            }
        }
        
        _canvas.enabled = false;
    }

    /// <summary>
    /// Updates the order ticket UI with the specified ingredients list and sets the canvas to be active.
    /// </summary>
    /// <param name="ingredients">The dictionary of ingredients for this order ticket.</param>
    /// <param name="cookTime">The cook time necessary for the meat on this order ticket.</param>
    /// <param name="soda">The soda needed for this order ticket,</param>
    public void UpdateOrder(Dictionary<TypeOfIngredient, GameObject> ingredients, int cookTime, GameObject soda)
    {
        foreach (TypeOfIngredient type in ingredients.Keys)
        {
            if (ingredients[type] != null)
            {
                _images[type].sprite = ingredients[type].GetComponent<SpriteRenderer>().sprite;
            }
            else
            {
                _textMeshes[type].text = NullObjectString;
                _images[type].color = new Color(1, 1, 1, 0);
            }
        }

        cookTimeImage.sprite = cookTime switch
        {
            1 => cookTimeImages[0],
            2 => cookTimeImages[1],
            3 => cookTimeImages[2],
            4 => cookTimeImages[3],
            _ => null
        };
        
        sodaImage.sprite = soda.GetComponent<SpriteRenderer>().sprite;
        
        _canvas.enabled = true;
    }

    /// <summary>
    /// 
    /// </summary>
    private void ResetOrderCanvas()
    {
        _canvas.enabled = false;
    }

    /// <summary>
    /// 
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnOrderComplete -= ResetOrderCanvas;
    }
}