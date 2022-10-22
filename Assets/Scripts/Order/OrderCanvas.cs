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
    /// 
    /// </summary>
    [SerializeField] private TextMeshProUGUI[] _ingredientsTexts;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Image[] _ingredientsImages;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Image[] _cookTimes;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Image _cookTime;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private Image _soda;
    
    /// <summary>
    /// 
    /// </summary>
    private Dictionary<TypeOfIngredient, TextMeshProUGUI> _textMeshes =
        new Dictionary<TypeOfIngredient, TextMeshProUGUI>();
    
    /// <summary>
    /// 
    /// </summary>
    private Dictionary<TypeOfIngredient, Image> _images = new Dictionary<TypeOfIngredient, Image>();

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
                _textMeshes[type].text = ingredients[type].name;
                _images[type].sprite = ingredients[type].GetComponent<SpriteRenderer>().sprite;
            }
            else
            {
                _textMeshes[type].text = _nullObjectString;
                _images[type].sprite = null;
            }
        }
        
        _cookTime.sprite = cookTime switch
        {
            1 => _cookTimes[0].sprite,
            2 => _cookTimes[1].sprite,
            3 => _cookTimes[2].sprite,
            4 => _cookTimes[3].sprite,
            _ => null
        };
        
        _soda.sprite = soda.GetComponent<SpriteRenderer>().sprite;
        
        gameObject.SetActive(true);
    }
}