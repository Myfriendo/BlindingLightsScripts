using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player interaction with nearby interactable objects.
public class PlayerInteract : MonoBehaviour
{
    // The camera used for raycasting to detect interactable objects
    private Camera cam;

    // The maximum distance for interaction raycasting
    [SerializeField]
    private float distance = 5f;

    // The layer mask for raycasting, specifying which layers to interact with
    [SerializeField]
    private LayerMask mask;

    // Reference to the player UI manager
    private PlayerUI playerUI;

    // Reference to the input manager for handling player input
    private InputManager inputManager;

    // Start is called before the first frame update
    void Start()
    {
        // Get the camera component from the PlayerLook script
        cam = GetComponent<PlayerLook>().cam;

        // Get references to player UI and input manager components
        playerUI = GetComponent<PlayerUI>();
        inputManager = GetComponent<InputManager>();
    }

    // Update is called once per frame
    void Update()
    {   
        // Clear any previous interaction text
        playerUI.UpdateText(string.Empty);

        // Create a ray from the camera's position and direction
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        Debug.DrawRay(ray.origin, ray.direction * distance);

        // Store information about the object that was hit by the ray
        RaycastHit hitInfo;
        
        // Perform raycasting to detect interactable objects
        if (Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            // Check if the hit object has an Interactable component
            if(hitInfo.collider.GetComponent<Interactable>())
            {   
                // Get the Interactable component from the hit object
                Interactable interactable = hitInfo.collider.GetComponent<Interactable>();

                // Update the player UI with the prompt message of the interactable
                playerUI.UpdateText(interactable.promptMessage);

                // Check if the interaction input is triggered
                if(inputManager.onFoot.Interact.triggered)
                {
                    // Call the BaseInteract method of the interactable
                    interactable.BaseInteract(); 
                }
            }
        }
    }
}
