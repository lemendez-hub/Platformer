using TMPro;
using UnityEngine;

public class TimeControl : MonoBehaviour
{
    public TextMeshProUGUI timetext; // Displays the time left
    public TextMeshProUGUI gameOverText; // Displays the game over message
    float timeLeft = 500; // Regular amount of time
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeLeft = 100; // Amount required for part 2
        gameOverText.enabled = false; // Hides the game over text at the start
    }
    
    // Update is called once per frame
    void Update()
    {
        timeLeft -= Time.deltaTime; // Decrease time
        timetext.text = $"Time\n {((int)timeLeft).ToString()}"; // Update time text
        if(timeLeft <= 0) // Checks if time is up
        {
            timeLeft = 0; // To not go negative
            Debug.Log("Time is up!\nGame Over!\nYou Lose!"); // Log game over message
            gameOverText.enabled = true; // Show game over text
        }
    }
}