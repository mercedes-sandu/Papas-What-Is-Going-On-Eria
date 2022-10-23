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
    [SerializeField] private TextMeshProUGUI[] _ingredientsTexts;
    
    /// <summary>
    /// The ingredients images.
    /// </summary>
    [SerializeField] private Image[] _ingredientsImages;

    /// <summary>
    /// The cook time sprites.
    /// </summary>
    [SerializeField] private Sprite[] _cookTimes;
    
    /// <summary>
    /// The cook time sprite for this order.
    /// </summary>
    [SerializeField] private Image _cookTime;

    /// <summary>
    /// The soda.
    /// </summary>
    [SerializeField] private Image _soda;
    
    /// <summary>
    /// The dictionary of ingredients mapped to their text objects.
    /// </summary>
    private Dictionary<TypeOfIngredient, TextMeshProUGUI> _textMeshes =
        new Dictionary<TypeOfIngredient, TextMeshProUGUI>();
    
    /// <summary>
    /// The dictionary of ingredients mapped to their images.
    /// </summary>
    private Dictionary<TypeOfIngredient, Image> _images = new Dictionary<TypeOfIngredient, Image>();
    
    // private List<TextMeshProUGUI> _textMeshes = new List<TextMeshProUGUI>();
    // private List<Image> _images = new List<Image>();

    /// <summary>
    /// To be appended to text if there is no ingredient for a particular ingredient type.
    /// </summary>
    private string _nullObjectString = "        ???";

    /// <summary>
    /// Sets the canvas to be inactive initially.
    /// </summary>
    void Start()
    {
        int counter = 0;
        foreach (TypeOfIngredient type in TypeOfIngredient.GetValues(typeof(TypeOfIngredient)))
        {
            _textMeshes.Add(type, _ingredientsTexts[counter]);
            _images.Add(type, _ingredientsImages[counter]);
            counter++;
        }

        // for (int i = 0; i < 6; i++)
        // {
        //     _textMeshes.Add(_ingredientsTexts[i]);
        //     _images.Add(_ingredientsImages[i]);
        // }
        
        gameObject.SetActive(false);
    }

    /// <summary>
    /// Updates the order ticket UI with the specified ingredients list and sets the canvas to be active.
    /// </summary>
    /// <param name="ingredients">The dictionary of ingredients for this order ticket.</param>
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
                _textMeshes[type].text = _nullObjectString;
                _images[type].sprite = null;
            }
        }

        // int counter = 0;
        // foreach (TypeOfIngredient type in ingredients.Keys)
        // {
        //     if (ingredients[type] != null)
        //     {
        //         _images[counter].sprite = ingredients[type].GetComponent<SpriteRenderer>().sprite;
        //     }
        //     else
        //     {
        //         _textMeshes[counter].text = _nullObjectString;
        //         _images[counter].sprite = null;
        //     }
        //
        //     counter++;
        // }
        
        _cookTime.sprite = cookTime switch
        {
            1 => _cookTimes[0],
            2 => _cookTimes[1],
            3 => _cookTimes[2],
            4 => _cookTimes[3],
            _ => null
        };
        
        _soda.sprite = soda.GetComponent<SpriteRenderer>().sprite;
        
        gameObject.SetActive(true);
    }
}