using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// The base class for all interactable objects in the game
public abstract class Interactable : MonoBehaviour
{
    // Flag indicating whether this interactable uses events
    public bool useEvents;

    // The message displayed to the player when they are in range of the interactable
    [SerializeField]
    public string promptMessage;

    // This function will be called when the player looks at the object
    // Returns the prompt message to be displayed to the player
    public virtual string Onlook()
    {
        return promptMessage;
    }

    // The base interaction method that is called when the player interacts with the object
    public void BaseInteract()
    {   
        // If useEvents is true, invoke the InteractionEvent's OnInteract event (if available)
        if(useEvents)
            GetComponent<InteractionEvent>().OnInteract.Invoke();
        
        // Call the Interact method (to be implemented in child classes)
        Interact();
    }

    // The method to be implemented in child classes to define specific interactions
    protected virtual void Interact()
    {
        // This function is meant to be overridden in child classes
        // Child classes should provide specific interaction logic here
    }
}
