using UnityEngine;

[RequireComponent(typeof(PlayerControl))]
public class Boundaries : MonoBehaviour
{
    /// <summary>
    /// Vector containing the boundaries of the camera screen.
    /// </summary>
    private Vector2 _screenBounds;

    /// <summary>
    /// The object's width.
    /// </summary>
    private float _objectWidth;

    /// <summary>
    /// The object's height.
    /// </summary>
    private float _objectHeight;

    /// <summary>
    /// Initializes the screen bounds.
    /// </summary>
    void Start()
    {
        _screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 
                Camera.main.transform.position.z));
        _objectWidth = gameObject.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        _objectHeight = gameObject.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }
    
    /// <summary>
    /// Ensures that the GameObject transform does not go out of bounds.
    /// </summary>
    void LateUpdate()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x, _screenBounds.x * -1 + _objectWidth, 
            _screenBounds.x - _objectWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, _screenBounds.y * -1 + _objectHeight, 
            _screenBounds.y - _objectHeight);
        transform.position = viewPos;
    }
}