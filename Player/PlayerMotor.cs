using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Handles player movement, including walking, jumping, crouching, and sprinting.
public class PlayerMotor : MonoBehaviour
{
    // Reference to the CharacterController component for player movement
    private CharacterController controller;
    // The current velocity of the player in the world
    private Vector3 playerVelocity;
    // Flag indicating whether the player is currently on the ground
    private bool isGrounded;
    // Flag indicating whether the crouch height is lerping
    private bool lerpCrouch;
    // Flag indicating whether the player is crouching
    private bool crouching;
    // Flag indicating whether the player is sprinting
    private bool sprinting;
    // Timer used for lerping the crouch height
    public float crouchTimer;
    // The base speed of the player
    public float speed = 5f;
    // The gravitational force applied to the player
    [SerializeField] public float gravity = -9.81f;
    // The height the player can jump
    public float jumpHeight = 1.5f;
    // Start is called before the first frame update
    void Start()
    {
        // Get the CharacterController component attached to the player
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Check if the player is grounded
        isGrounded = controller.isGrounded;

        // Handle lerping of crouch height
        if(lerpCrouch)
        {   
            // Increment crouch timer
            crouchTimer += Time.deltaTime / 1;
            
            // Calculate the normalized percentage of the crouch timer
            float p = crouchTimer / 1;
            p *= p;

            // Lerping the crouch height based on crouch status
            if(crouching)
            {
                controller.height = Mathf.Lerp(controller.height, 1f, p);
            }
            else
            {
                controller.height = Mathf.Lerp(controller.height, 2f, p);
            }

            // Increment crouch timer for lerping speed
            crouchTimer += Time.deltaTime * 3;

            // Reset lerping flags when the lerping is complete
            if(p > 1)
            {
                lerpCrouch = false;
                crouchTimer = 0;
            }
        }
    }

    // Process player movement based on input values
    public void ProcessMove(Vector2 input)
    {
        // Calculate the move direction based on input values
        Vector3 moveDirection = Vector3.zero;
        moveDirection.x = input.x;
        moveDirection.z = input.y;

        // Move the player using the CharacterController
        controller.Move(transform.TransformDirection(moveDirection) * (speed * Time.deltaTime));

        // Apply gravity to the player
        playerVelocity.y += gravity * Time.deltaTime;

        // Move the player vertically using the CharacterController
        controller.Move(playerVelocity * Time.deltaTime);
    }
    
    // Make the player jump if on the ground
    public void Jump()
    {
        if (isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -5f * gravity);
        }
    }
    
    // Toggle crouch status and initiate crouch height lerping
    public void Crouch()
    {
        crouching = !crouching;
        crouchTimer = 0;
        lerpCrouch = true;
    }
    
    // Toggle sprint status and adjust player speed accordingly
    public void Sprint()
    {   
        sprinting = !sprinting;
        speed = sprinting ? 8f : 5f;
    }
}
