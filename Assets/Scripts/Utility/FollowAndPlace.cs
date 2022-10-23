using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowAndPlace : MonoBehaviour
{
    /// <summary>
    /// True if the object has been placed, false otherwise.
    /// </summary>
    private static bool _placedObject = false;
    
    /// <summary>
    /// Checks if the object has been placed.
    /// </summary>
    void Update()
    {
        if (!_placedObject)
        {
            transform.position = Input.mousePosition;
        }
    }
    
    /// <summary>
    /// Places the specified object on the plate.
    /// </summary>
    /// <param name="obj">The object to be placed.</param>
    /// <param name="plate">The plate.</param>
    public static void PlaceObject(GameObject obj, GameObject plate)
    {
        _placedObject = true;
        obj.transform.SetParent(plate.transform, true);
        obj.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        Destroy(obj.GetComponent<FollowAndPlace>());
        // var placedObject = Instantiate(obj, obj.transform.position, Quaternion.identity, plate.transform);
        // placedObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
    }
}
