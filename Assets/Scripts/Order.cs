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
    [SerializeField] private List<GameObject> _ingredients = new List<GameObject>();

    /// <summary>
    /// True if the order has been completed, false otherwise.
    /// </summary>
    [SerializeField] private bool _isComplete;

    /// <summary>
    /// Initializes the ingredients list.
    /// </summary>
    void Start()
    {
        GetIngredients();
    }

    /// <summary>
    /// Picks a random ingredient from each type of ingredient and adds its prefab to _ingredients.
    /// </summary>
    private void GetIngredients()
    {
        foreach (TypeOfIngredient type in TypeOfIngredient.GetValues(typeof(TypeOfIngredient)))
        {
            var resources = Resources.LoadAll<GameObject>("Prefabs/" + type);
            var prefabs = resources
                .Where(x => x.GetComponent<Ingredient>() != null && x.GetComponent<Ingredient>().CanUse())
                .ToList();
            if (prefabs.Count != 0)
            {
                _ingredients.Add(prefabs[Random.Range(0, prefabs.Count)]);
            }
        }
    }
}