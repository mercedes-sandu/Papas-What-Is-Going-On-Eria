using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AssemblerCanvas : MonoBehaviour
{
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject cookedMeat;
    
    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject plate;

    /// <summary>
    /// 
    /// </summary>
    [SerializeField] private GameObject table;

    /// <summary>
    /// 
    /// </summary>
    private float _centerX;
    
    /// <summary>
    /// 
    /// </summary>
    private List<GameObject> _stackedItems = new List<GameObject>();

    /// <summary>
    /// 
    /// </summary>
    private bool _placingObject = false;

    /// <summary>
    /// 
    /// </summary>
    private GameObject _currentHeldObject;

    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        _centerX = plate.transform.position.x; // TODO: check if this is actually correct
        // var meat = CookerCanvas.Instance.GetCookedMeat();
        // if (meat != null)
        // {
        //     cookedMeat.GetComponent<Image>().sprite = CookerCanvas.Instance.GetCookedMeat().sprite;
        //     cookedMeat.GetComponent<Image>().color = CookerCanvas.Instance.GetCookedMeat().color;
        // }
        gameObject.SetActive(false);
    }

    void Update()
    {
        if (_placingObject)
        {
            if (Input.GetMouseButtonDown(0))
            {
                FollowAndPlace.PlaceObject(_currentHeldObject, plate);
                _currentHeldObject = null;
                _placingObject = false;
            }
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="item"></param>
    public void CreateItem(GameObject item)
    {
        var newItem = new GameObject(item.name, typeof(RectTransform), typeof(Image), 
            typeof(FollowAndPlace));
        newItem.GetComponent<RectTransform>().sizeDelta = new Vector2(500, 500);
        newItem.GetComponent<Image>().sprite = item.GetComponent<SpriteRenderer>().sprite;
        newItem.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        Instantiate(newItem, Camera.main.ScreenToWorldPoint(Input.mousePosition), Quaternion.identity, 
            table.transform);
        _currentHeldObject = newItem;
        _placingObject = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void CompleteFoodOrder()
    {
        
    }

    /// <summary>
    /// 
    /// </summary>
    public void CloseCanvas()
    {
        gameObject.SetActive(false);
    }
}
