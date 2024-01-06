using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

// Manages the UI elements related to the player, such as interaction prompts.
public class PlayerUI : MonoBehaviour
{   
    // Reference to the TextMeshProUGUI component for displaying interaction prompts
    [SerializeField]
    private TextMeshProUGUI promptText;

    // Start is called before the first frame update
    void Start()
    {
        // Initialization code can be added here if needed
    }

    // Update is called once per frame
    // Update the displayed text with the provided interaction prompt message.
    public void UpdateText(string promptMessage)
    {
        // Set the promptText component's text to the provided promptMessage
        promptText.text = promptMessage;
    }
}
