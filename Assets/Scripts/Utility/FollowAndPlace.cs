using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FollowAndPlace : MonoBehaviour
{
    private static bool _placedObject = false;
    
    /// <summary>
    /// 
    /// </summary>
    void Update()
    {
        if (!_placedObject)
        {
            transform.position = Input.mousePosition;
        }
    }
    
    /// <summary>
    /// 
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="plate"></param>
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
