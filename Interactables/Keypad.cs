using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An interactable keypad that toggles the state of a door when interacted with.
public class Keypad : Interactable
{   
    // Reference to the door GameObject
    [SerializeField]
    private GameObject door;

    // Flag indicating whether the door is open
    private bool doorOpen;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can be added here if needed
    }

    // Update is called once per frame
    void Update()
    {
        // Update code can be added here if needed
    }

    // Interact method overridden from the base class
    // Toggles the state of the door when the keypad is interacted with
    protected override void Interact()
    {   
        // Toggle the doorOpen flag
        doorOpen = !doorOpen;

        // Set the "IsOpen" parameter of the door's Animator component based on the doorOpen flag
        door.GetComponent<Animator>().SetBool("IsOpen", doorOpen);

        // Log a message indicating the interaction with the keypad
        Debug.Log("Interacting with " + gameObject.name);
    }
}
