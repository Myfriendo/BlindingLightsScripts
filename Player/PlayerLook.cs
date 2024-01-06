using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player camera movement and rotation.
public class PlayerLook : MonoBehaviour
{
    // The camera used for player's view
    public Camera cam;

    // Current rotation around the x-axis
    private float xRotation = 0f;

    // Sensitivity for horizontal (x-axis) camera movement
    public float xSensitivity = 30f;

    // Sensitivity for vertical (y-axis) camera movement
    public float ySensitivity = 30f;

    // Process player's look based on input values.
    public void ProcessLook(Vector2 input)
    {
        // Calculate the horizontal and vertical rotation based on input and sensitivity
        float mouseX = input.x * xSensitivity * Time.deltaTime;
        float mouseY = input.y * ySensitivity * Time.deltaTime;

        // Update the xRotation based on the vertical input and clamp it within a specific range
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply the rotation to the camera around the x-axis
        cam.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotate the entire player object around the y-axis based on horizontal input
        transform.Rotate(Vector3.up * mouseX);
    }
}
