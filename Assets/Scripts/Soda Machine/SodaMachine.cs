using UnityEngine;

public class SodaMachine : MonoBehaviour, IInteractable
{
    /// <summary>
    /// The UI canvas corresponding to the soda machine.
    /// </summary>
    [SerializeField] private GameObject sodaMachineCanvas;
    
    /// <summary>
    /// Calls for the UI to be updated.
    /// </summary>
    /// <param name="interactor">The interactor component.</param>
    /// <returns>True if the interaction was successful, false otherwise.</returns>
    public bool Interact(Interactor interactor)
    {
        sodaMachineCanvas.GetComponent<Canvas>().enabled = true;
        return true;
    }
}