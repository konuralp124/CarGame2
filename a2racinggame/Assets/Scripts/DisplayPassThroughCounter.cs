using UnityEngine;
using TMPro; // Import the TextMeshPro namespace

public class DisplayPassThroughCounter : MonoBehaviour
{
    public PassThroughCounter passThroughCounter; // Reference to the PassThroughCounter script
    public TextMeshProUGUI passThroughText; // Reference to your TextMeshPro text element

    void Update()
    {
        // Check if the references are set
        if(passThroughCounter != null && passThroughText != null)
        {
            // Update the TextMeshPro text to display the current pass-through count
            passThroughText.text = "LAP: " + passThroughCounter.GetCounter().ToString();
        }
    }
}
