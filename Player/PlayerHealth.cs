using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Manages the health of the player and updates the health UI accordingly.
public class PlayerHealth : MonoBehaviour
{
    // Current health of the player
    private float health;

    // Timer used for lerping between health values for smooth UI transitions
    private float lerpTimer;

    // Maximum health the player can have
    public float maxHealth = 150f;

    // Speed of the health bar chip animation
    public float chipSpeed = 0.5f;

    // Reference to the front and back health bar images in the UI
    public Image frontHealthBar;
    public Image backHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize health to maximum at the start
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        // Ensure health stays within the valid range
        health = Mathf.Clamp(health, 0, maxHealth);

        // Update the health UI to reflect the current health value
        UpdateHealthUI();

        // Example: Uncomment the lines below to test TakeDamage and Heal methods with keyboard input
        // if (Input.GetKeyDown(KeyCode.L)) { TakeDamage(Random.Range(5f, 10f)); }
        // if (Input.GetKeyDown(KeyCode.K)) { Heal(Random.Range(5f, 10f)); }
    }

    // Updates the health UI based on the current health value
    public void UpdateHealthUI()
    {   
        // Debug log for testing purposes
        Debug.Log(health);

        // Get current fill amounts of front and back health bars
        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;

        // Calculate the health percentage
        float healthPercent = health / maxHealth;

        // Update UI based on health changes
        if (fillB > healthPercent)
        {
            frontHealthBar.fillAmount = healthPercent;
            backHealthBar.color = Color.red;

            // Lerping animation for smooth transition
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillB, healthPercent, percentComplete);
        }

        if (fillF < healthPercent)
        {   
            backHealthBar.color = Color.green;

            // Lerping animation for smooth transition
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillF, healthPercent, percentComplete);
        }
    }

    // Reduces the player's health by a specified amount
    public void TakeDamage(float amount)
    {
        health -= amount;
        // Reset the lerping timer for smooth UI transition
        lerpTimer = 0f;
    }

    // Increases the player's health by a specified amount
    public void Heal(float amount)
    {
        health += amount;
        // Reset the lerping timer for smooth UI transition
        lerpTimer = 0f;
    }
}
