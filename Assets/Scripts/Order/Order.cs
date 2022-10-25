using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Scripts;
using UnityEngine;
using Random = UnityEngine.Random;

public class Order : MonoBehaviour
{
    /// <summary>
    /// An instance of the order that is accessible by all classes.
    /// </summary>
    public static Order Instance = null;
    
    /// <summary>
    /// The list of necessary ingredients for this order.
    /// </summary>
    private Dictionary<TypeOfIngredient, GameObject> _ingredients = new Dictionary<TypeOfIngredient, GameObject>();

    /// <summary>
    /// The cook time for the meat for this order.
    /// </summary>
    private int _cookTime;

    /// <summary>
    /// The soda for this order.
    /// </summary>
    private GameObject _soda;
    
    /// <summary>
    /// 
    /// </summary>
    private Dictionary<TypeOfIngredient, List<GameObject>> _ingredientPrefabs 
        = new Dictionary<TypeOfIngredient, List<GameObject>>();
    
    /// <summary>
    /// 
    /// </summary>
    private GameObject[] _sodaPrefabs;

    /// <summary>
    /// 
    /// </summary>
    private List<TypeOfIngredient> _types;

    /// <summary>
    /// Creates instance and subscribes to GameEvents.
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

        GameEvent.OnOrderComplete += RemoveRandomItem;
    }

    /// <summary>
    /// Gets the ingredient prefabs.
    /// </summary>
    void Start()
    {
        // Get all the food ingredient prefabs.
        foreach (TypeOfIngredient type in TypeOfIngredient.GetValues(typeof(TypeOfIngredient)))
        {
            if (!type.Equals(TypeOfIngredient.None))
            {
                _ingredientPrefabs[type] = Resources.LoadAll<GameObject>("Ingredient Prefabs/" + type).ToList();
                _types.Add(type);
            }
        }
        
        // Get all the soda prefabs.
        _sodaPrefabs = Resources.LoadAll<GameObject>("Ingredient Prefabs/Soda");
    }

    /// <summary>
    /// Picks a random ingredient from each type of ingredient and adds its prefab to _ingredients.
    /// </summary>
    public void InitializeOrder()
    {
        // Get the food ingredients.
        foreach (TypeOfIngredient type in _types)
        {
            var prefabs = _ingredientPrefabs[type]
                .Where(x => x.GetComponent<Ingredient>() != null && x.GetComponent<Ingredient>().CanUse())
                .ToList();
            _ingredients[type] = prefabs.Count != 0 ? prefabs[Random.Range(0, prefabs.Count)] : null;
        }

        // Get the cook time for the meat.
        if (_ingredients.ContainsKey(TypeOfIngredient.Meat)) _cookTime = Random.Range(1, 5);
        
        // Get the soda.
        _soda = _sodaPrefabs[Random.Range(0, _sodaPrefabs.Length)];
    }
    
    /// <summary>
    /// Returns the ingredients list.
    /// </summary>
    /// <returns>The dictionary of necessary ingredients for the order.</returns>
    public Dictionary<TypeOfIngredient, GameObject> GetIngredientsDict() => _ingredients;
    
    /// <summary>
    /// Returns the cook time for the meat for this order.
    /// </summary>
    /// <returns>The cook time.</returns>
    public int GetCookTime() => _cookTime;
    
    /// <summary>
    /// Returns the soda object for this order.
    /// </summary>
    /// <returns>The soda.</returns>
    public GameObject GetSoda() => _soda;

    /// <summary>
    /// Sets the usability of a random ingredient to false.
    /// </summary>
    private void RemoveRandomItem()
    {
        TypeOfIngredient randomType = _types[Random.Range(0, _types.Count)];
        _ingredientPrefabs[randomType][Random.Range(0, _ingredientPrefabs[randomType].Count)].GetComponent<Ingredient>()
            .SetUsability(false);
    }
    
    /// <summary>
    /// Unsubscribes from GameEvents.
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnOrderComplete -= RemoveRandomItem;
    }
}