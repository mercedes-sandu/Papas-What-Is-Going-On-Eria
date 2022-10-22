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
    /// True if the order has been completed, false otherwise.
    /// </summary>
    [SerializeField] private bool _isComplete;

    /// <summary>
    /// Picks a random ingredient from each type of ingredient and adds its prefab to _ingredients.
    /// </summary>
    public void InitializeOrder()
    {
        foreach (TypeOfIngredient type in TypeOfIngredient.GetValues(typeof(TypeOfIngredient)))
        {
            var resources = Resources.LoadAll<GameObject>("Prefabs/" + type);
            var prefabs = resources
                .Where(x => x.GetComponent<Ingredient>() != null && x.GetComponent<Ingredient>().CanUse())
                .ToList();
            _ingredients.Add(type, prefabs.Count != 0 ? prefabs[Random.Range(0, prefabs.Count)] : null);
        }
    }
    
    /// <summary>
    /// Returns the ingredients list.
    /// </summary>
    /// <returns>The dictionary of necessary ingredients for the order.</returns>
    public Dictionary<TypeOfIngredient, GameObject> GetIngredientsDict() => _ingredients;
}