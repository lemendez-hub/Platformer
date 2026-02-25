using TMPro;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public TextMeshProUGUI timetext; // Reference to element that displays remaining time
    public TextMeshProUGUI gameOverText; // Reference to element that displays "Game Over" message

    public float timeLeft = 500; // Remaining time
    
    void Start()
    {
        timeLeft = 100; // Sets time to 100 at start
        gameOverText.enabled = false; // Hides the "Game Over" text at the start
    }
    
    void Update()
    {
        timeLeft -= Time.deltaTime; // Decreases remaining time
        timetext.text = $"Time\n {((int)timeLeft).ToString()}"; // To update the UI text displaying remaining time
        
        if(timeLeft <= 0) // Checking if timer is 0
        {
            timeLeft = 0; // To not go into negatives

            Debug.Log("Time is up!\nGame Over!\nYou Lose!"); // Message to the console

            gameOverText.enabled = true; // Displays the "Game Over" text
        }
    }
}