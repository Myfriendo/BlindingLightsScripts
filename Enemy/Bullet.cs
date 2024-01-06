using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Represents a bullet in the game that can collide with other objects.
public class Bullet : MonoBehaviour
{
    // Called when a collision occurs with another object
    private void OnCollisionEnter(Collision collision)
    {   
        // Get the transform of the object that the bullet collided with
        Transform hitTransform = collision.transform;

        // Check if the collided object has the "Player" tag
        if (hitTransform.CompareTag("Player"))
        {   
            // Log a message indicating that the player was hit
            Debug.Log("Hit Player");

            // Inflict damage to the player by calling the TakeDamage method in the PlayerHealth script
            hitTransform.GetComponent<PlayerHealth>().TakeDamage(10);
        }

        // Destroy the bullet GameObject
        Destroy(gameObject);
    }
}
