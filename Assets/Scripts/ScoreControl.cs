using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class ScoreControl : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Reference to element that displays the score
    
    private int score = 0; // Sets the current code to 0
    
    void Update()
    {
        scoreText.text = "Mario\n" + score.ToString("D6"); // To update the UI text, formatting it as a 6-digit
    }
    
    public void AddScore(int amount)
    {
        score += amount; // Adds the specified amount to the current score
    }
}