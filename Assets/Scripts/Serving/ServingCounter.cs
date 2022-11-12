using UnityEngine;

public class ServingCounter : MonoBehaviour, IInteractable
{
    /// <summary>
    /// The coin audio clip.
    /// </summary>
    [SerializeField] private AudioClip coinClip;
    
    /// <summary>
    /// The audio source.
    /// </summary>
    private AudioSource _audioSource;

    /// <summary>
    /// Initializes components.
    /// </summary>
    void Start()
    {
        _audioSource = GetComponent<AudioSource>();    
    }
    
    /// <summary>
    /// Completes the order.
    /// </summary>
    /// <param name="interactor">The interactor component.</param>
    /// <returns>True if the interaction was successful, false otherwise.</returns>
    public bool Interact(Interactor interactor)
    {
        if (Order.Instance.GetIngredientsDict().Count > 0)
        {
            _audioSource.PlayOneShot(coinClip, 0.3f);
            GameEvent.CompleteOrder();
        }
        return true;
    }
}