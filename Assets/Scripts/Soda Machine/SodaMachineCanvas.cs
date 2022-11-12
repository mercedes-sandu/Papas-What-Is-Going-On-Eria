using UnityEngine;
using UnityEngine.UI;

public class SodaMachineCanvas : MonoBehaviour
{
    /// <summary>
    /// The soda buttons.
    /// </summary>
    [SerializeField] private GameObject[] sodaButtons;

    /// <summary>
    /// The soda liquid images.
    /// </summary>
    [SerializeField] private Sprite[] sodaImages;

    /// <summary>
    /// The soda stream.
    /// </summary>
    [SerializeField] private Image sodaStream;

    /// <summary>
    /// The soda graphic in the game.
    /// </summary>
    [SerializeField] private GameObject soda;

    /// <summary>
    /// The soda prefab which is being poured.
    /// </summary>
    private GameObject _pouredSoda;

    /// <summary>
    /// The canvas component.
    /// </summary>
    private Canvas _canvas;

    /// <summary>
    /// The animator component.
    /// </summary>
    private Animator _anim;

    /// <summary>
    /// Subscribes to GameEvents.
    /// </summary>
    void Awake()
    {
        GameEvent.OnOrderComplete += ResetSodaMachineCanvas;
    }
    
    /// <summary>
    /// Sets the UI canvas to be inactive.
    /// </summary>
    void Start()
    {
        sodaStream.color = new Color(1, 1, 1, 0);
        _anim = GetComponent<Animator>();
        _anim.SetBool("IsFilling", false);
        _canvas = GetComponent<Canvas>();
        _canvas.enabled = false;
    }

    /// <summary>
    /// Detects input.
    /// </summary>
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseCanvas();
        }
    }

    /// <summary>
    /// Sets the soda to be poured and triggers the filling animation.
    /// </summary>
    /// <param name="selectedSoda">The soda which is being poured.</param>
    public void PourSoda(GameObject selectedSoda)
    {
        _pouredSoda = selectedSoda;
        foreach (var button in sodaButtons)
        {
            button.GetComponent<Button>().interactable = false;
        }
        _anim.SetBool("IsFilling", true);
    }
    
    /// <summary>
    /// Assigns the appropriate image based off of the index of the soda.
    /// </summary>
    /// <param name="index"></param>
    public void SetSodaIndex(int index)
    {
        soda.GetComponent<Image>().sprite = sodaImages[index];
        sodaStream.GetComponent<Image>().sprite = sodaImages[index];
    }

    /// <summary>
    /// Closes the soda machine canvas.
    /// </summary>
    public void CloseCanvas()
    {
        _canvas.enabled = false;
    }
    
    /// <summary>
    /// Completes the soda order.
    /// </summary>
    public void CompleteSodaOrder()
    {
        GameEvent.CompleteSodaOrder(Order.Instance.GetSoda(), _pouredSoda);
        _anim.SetBool("IsFilling", false);
    }
    
    /// <summary>
    /// Resets the canvas.
    /// </summary>
    private void ResetSodaMachineCanvas()
    {
        foreach (var button in sodaButtons)
        {
            button.GetComponent<Button>().interactable = false;
        }
        
        sodaStream.color = new Color(1, 1, 1, 0);
        _anim.SetBool("IsFilling", false);
    }
    
    /// <summary>
    /// Unsubscribes from GameEvents.
    /// </summary>
    void OnDestroy()
    {
        GameEvent.OnOrderComplete -= ResetSodaMachineCanvas;
    }
}