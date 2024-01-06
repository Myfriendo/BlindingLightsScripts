using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// An interactable cube that can be collected, triggering a particle effect.
// It's for future ammunition collection
public class CollectCube : Interactable
{
    // Reference to the particle effect GameObject
    public GameObject particle;

    // Interact method overridden from the base class
    // Destroys the cube and spawns a particle effect at its position
    protected override void Interact()
    {   
        // Destroy the current cube
        Destroy(gameObject);

        // Instantiate the particle effect at the cube's position with no rotation
        Instantiate(particle, transform.position, Quaternion.identity);
        // we later incluede adding immunation to our inventory
    }
}
