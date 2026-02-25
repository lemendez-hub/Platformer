using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class CharacterCollision : MonoBehaviour
{
    List<GameObject> usedBoxes = new List<GameObject>(); // To store question boxes (coins) that have been collected
    
    ScoreControl sc; // Reference to ScoreControl script
    CharacterController controller; // Reference to CharacterControl component
    CoinTracker ct; // Reference to CoinTracker script
    TimeControl tc; // Reference to TimeControl script
    
    Vector3 startPosition; // To store the player's starting position
    
    void Awake()
    {
        sc = FindAnyObjectByType<ScoreControl>(); // sc is assinged a ScoreControl instance
        controller = GetComponent<CharacterController>(); // Gets the CharacterController attached to this GameObject
        ct = FindAnyObjectByType<CoinTracker>(); // ct is assigned a CoinTracker instance
        tc = FindAnyObjectByType<TimeControl>(); // tc is assigned a TimeControl instance
        
        startPosition = transform.position; // Stores the initial position
    }
    
    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if(collision.gameObject.CompareTag("Brick") && Keyboard.current.spaceKey.isPressed) // If colliding with a Brick and space is pressed
        {
            Destroy(collision.gameObject); // Destroy Brick
            sc.AddScore(100); // Add 100 to score
        }
        
        if(collision.gameObject.CompareTag("Question") && Keyboard.current.spaceKey.isPressed) // If colliding with a Question and space is pressed
        {
            if(usedBoxes.Contains(collision.gameObject)) // Checks if the Question is already used
            {
                return; // Returns to prevent reuse
            }
            usedBoxes.Add(collision.gameObject); // Adds to the list, marked as used

            ct.coinCount++; // Increments coin count
            sc.AddScore(100); // Adds 100 to score
        }
        
        if(collision.gameObject.CompareTag("Enemy")) // If colliding with an enemy
        {
            Collider enemyCol = collision.collider; // Getting enemy collider
            
            float playerFeetY = transform.position.y; // Gets player's y-pos
            float enemyTopY = enemyCol.bounds.max.y; // Gets the Y boundary of enemy collider
            
            bool isAboveEnemy = playerFeetY > enemyTopY - 0.15f; // Check if player is above enemy
            bool isFalling = controller.velocity.y < 0f; // Checks if player is moving down
            
            if(isAboveEnemy && isFalling) // Stomp, if player is above enemy and falling
            {
                Destroy(collision.gameObject); // Destroy enemy
                sc.AddScore(200); // Add 200 to score
            }
            else // Not above, example: right beside and gets hit
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reloads current scene / Death
            }
        }
        
        if(collision.gameObject.CompareTag("Pole")) // Colliding with Pole
        {
            Debug.Log("You Win"); // Win message
            int timeBonus = (int)tc.timeLeft; // Convert remaining time to int
            sc.AddScore(timeBonus); // Add remaining time to score
            tc.timeLeft = 0f; // Set time to 0 after adding it
        }

        if(transform.position.y < 0f) // Falling out
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reload current scene / Death
        }
    }
}