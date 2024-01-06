using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An interactable cube that changes its color when interacted with.
public class ChangeColourCube : Interactable
{
    // Index to keep track of the current color in the colors array
    private int colourIndex;

    // Array of colors that the cube can cycle through
    public Color[] colors;

    // Reference to the MeshRenderer component for changing the cube's color
    MeshRenderer mesh;

    // Start is called before the first frame update
    void Start()
    {
        // Get the MeshRenderer component attached to the cube
        mesh = GetComponent<MeshRenderer>();

        // Set the initial color of the cube to red
        mesh.material.color = Color.red;
    }

    // Interact method overridden from the base class
    // Changes the color of the cube to the next color in the colors array
    protected override void Interact()
    {
        // Increment the color index
        colourIndex++;

        // Check if the index exceeds the array length
        if (colourIndex >= colors.Length - 1)
        {
            // Reset the index to the beginning of the array
            colourIndex = 0;
        }

        // Set the cube's color to the next color in the array
        mesh.material.color = colors[colourIndex];
    }
}
