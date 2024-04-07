using UnityEngine;
using UnityEngine.SceneManagement;

public class PassThroughCounter : MonoBehaviour
{
    private int playerCounter = 0;
    private int aiCounter = 0;
    private float startTime;
    private bool playerFinished = false;
    private bool aiFinished = false;
    private float playerTime = float.MaxValue; // Initialize with max value to indicate not finished
    private float aiTime = float.MaxValue; // Initialize with max value to indicate not finished

    void Start()
    {
        // Start timing from the beginning of the scene
        startTime = Time.time;
    }

    void Update()
    {
        // Check if the player or AI has finished the race and not yet processed
        if (playerFinished && playerTime == float.MaxValue)
        {
            playerTime = Time.time - startTime;
            // Log the player's completion time
            Debug.Log($"Player finished in: {playerTime} seconds.");
            playerFinished = false; // Prevent further updates
            CheckEndCondition();
        }
        else if (aiFinished && aiTime == float.MaxValue)
        {
            aiTime = Time.time - startTime;
            // Log the AI's completion time
            Debug.Log($"AI finished in: {aiTime} seconds.");
            aiFinished = false; // Prevent further updates
            CheckEndCondition();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !playerFinished)
        {
            playerCounter++;
            if (playerCounter == 3)
            {
                playerFinished = true; // This will trigger the time calculation in Update
            }
        }
        else if (other.CompareTag("AI") && !aiFinished)
        {
            aiCounter++;
            if (aiCounter == 3)
            {
                aiFinished = true; // This will trigger the time calculation in Update
            }
        }
    }

    private void CheckEndCondition()
    {
        // Ensure both player and AI have finished to proceed with result calculation
        if (playerCounter == 3)
        {
                playerFinished = true; // This will trigger the time calculation in Update
            // Determine win or lose
                string result = playerTime < aiTime ? "Win" : "Lose";
                PlayerPrefs.SetString("RaceResult", result);

            // Load the game over scene
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }

    public int GetCounter()
    {
        return playerCounter;
    }
}
