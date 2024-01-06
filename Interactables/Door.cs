using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An interactable door that moves the player to a specific position when interacted with.
public class Door : Interactable
{
    // Reference to the player GameObject
    [SerializeField]
    private GameObject player;

    // Reference to the cube GameObject
    [SerializeField]
    private GameObject cube;

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
    // Moves the player to a new position above the cube when the door is interacted with
    protected override void Interact()
    {   
        // Set the player's position to be above the cube
        player.gameObject.transform.position = cube.gameObject.transform.position + new Vector3(0, 3, 0);
    }
}
