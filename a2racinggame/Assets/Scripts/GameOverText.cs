using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverText : MonoBehaviour
{
    public TextMeshProUGUI resultText; // Reference to your TextMeshPro text element

    // Start is called before the first frame update
    void Start()
    {
        // Retrieve the result stored in PlayerPrefs
        string result = PlayerPrefs.GetString("RaceResult", "Lose"); // Default to "Lose" if nothing is set

        // Update the text element with the result
        resultText.text = "You " + result + "!";
    }
}
