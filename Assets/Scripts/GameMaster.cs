using System.Collections;
using System.Collections.Generic;
using Scripts;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    /// <summary>
    /// An instance of the game master that is accessible by all classes.
    /// </summary>
    public static GameMaster Instance = null;

    // public Dictionary<TypeOfIngredient, string> IngredientPaths = new Dictionary<TypeOfIngredient, string>();

    [SerializeField] private float _levelTime;
    
    void Awake()
    {
        if (!Instance)
        {
            Instance = this;
        } else if (Instance != this)
        {
            Destroy(gameObject);
        }
        
        // SetUpDictionary();
    }
    
    void Start()
    {
        
    }
    
    void Update()
    {
        
    }

    /// <summary>
    /// Initializes the dictionary with all of the prefab folders of the various types of ingredients.
    /// </summary>
    // private void SetUpDictionary()
    // {
    //     foreach (TypeOfIngredient type in TypeOfIngredient.GetValues(typeof(TypeOfIngredient)))
    //     {
    //         string path = Application.dataPath;
    //         IngredientPaths.Add(type, path + "/Prefabs/" + type);
    //     }
    // }
}
