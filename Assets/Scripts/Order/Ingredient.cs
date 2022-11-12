using Scripts;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    /// <summary>
    /// The type of ingredient.
    /// </summary>
    [SerializeField] private TypeOfIngredient ingredient;
    
    /// <summary>
    /// True if the ingredient can be used, false otherwise.
    /// </summary>
    [SerializeField] private bool canUse = true;

    /// <summary>
    /// Returns whether the ingredient can be used.
    /// </summary>
    /// <returns>True if the ingredient can be used, false otherwise.</returns>
    public bool CanUse() => canUse;
    
    /// <summary>
    /// Sets whether the ingredient can be used.
    /// </summary>
    /// <param name="usable">True if the ingredient can be used, false otherwise.</param>
    public void SetUsability(bool usable) => canUse = usable;

    /// <summary>
    /// Returns the ingredient type for this object.
    /// </summary>
    /// <returns>The TypeOfIngredient.</returns>
    public TypeOfIngredient GetTypeOfIngredient() => ingredient;

    /// <summary>
    /// Sets the type of ingredient.
    /// </summary>
    /// <param name="type">The ingredient type.</param>
    public void SetTypeOfIngredient(TypeOfIngredient type) => ingredient = type;
}