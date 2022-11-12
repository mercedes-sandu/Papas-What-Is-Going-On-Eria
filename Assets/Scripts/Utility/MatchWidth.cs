using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class MatchWidth : MonoBehaviour {
    /// <summary>
    /// In-world distance between the left and right edges of the screen.
    /// </summary>
    public float sceneWidth = 20;

    /// <summary>
    /// The main camera.
    /// </summary>
    Camera _camera;
    
    /// <summary>
    /// Initialize the camera component.
    /// </summary>
    void Start() 
    {
        _camera = GetComponent<Camera>();
    }
    
    /// <summary>
    /// Adjusts the camera's height so that the desired scene width fits in view, even if the screen/window size
    /// changes dynamically.
    /// </summary>
    void Update() 
    {
        float unitsPerPixel = sceneWidth / Screen.width;
        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;
        _camera.orthographicSize = desiredHalfHeight;
    }
}