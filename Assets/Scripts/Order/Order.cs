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
    /// True if the order has been completed, false otherwise.
    /// </summary>
    [SerializeField] private bool isComplete;

    void Awake()
    {
        
    }

    /// <summary>
    /// Picks a random ingredient from each type of ingredient and adds its prefab to _ingredients.
    /// </summary>
    public void InitializeOrder()
    {
        isComplete = false;
        foreach (TypeOfIngredient type in TypeOfIngredient.GetValues(typeof(TypeOfIngredient)))
        {
            var resources = Resources.LoadAll<GameObject>("Ingredient Prefabs/" + type);
            var prefabs = resources
                .Where(x => x.GetComponent<Ingredient>() != null && x.GetComponent<Ingredient>().CanUse())
                .ToList();
            _ingredients[type] = prefabs.Count != 0 ? prefabs[Random.Range(0, prefabs.Count)] : null;
        }

        _cookTime = Random.Range(1, 5);
        
        var sodas = Resources.LoadAll<GameObject>("Ingredient Prefabs/Soda");
        _soda = sodas[Random.Range(0, sodas.Length)];
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
    /// Returns whether this order has been completed.
    /// </summary>
    /// <returns>True if this order has been completed, false otherwise.</returns>
    public bool IsComplete() => isComplete;

    private void CompleteOrder(Order order)
    {
        
    }
    
    void OnDestroy()
    {
        
    }
}