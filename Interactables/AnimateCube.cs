using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An interactable cube that can be animated using the Animator component.
public class AnimateCube : Interactable
{
    // Reference to the Animator component for controlling animations
    Animator animator;

    // The initial prompt message displayed when the cube is not animating
    private string startPrompt;
    
    // Start is called before the first frame update
    void Start()
    {
        // Get the Animator component attached to the cube
        animator = GetComponent<Animator>();

        // Store the initial prompt message
        startPrompt = promptMessage;    
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the Animator is in the "Default" state
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Default"))
        {
            // Set the prompt message to the initial prompt when not animating
            promptMessage = startPrompt;
        }
        else
        {
            // Set the prompt message to indicate that the cube is currently animating
            promptMessage = "Animating...";
        }
    }

    // Interact method overridden from the base class
    // Initiates the "Spin" animation when the player interacts with the cube
    protected override void Interact()
    {
        animator.Play("Spin");
    }
}
