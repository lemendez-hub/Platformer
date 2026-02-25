using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    TimeControl tc; // Reference to TimeControl script to access timeLeft
    
    float moveDistance = 3f; // Maximum distnace enemy will move
    float moveSpeed = 1.5f; // Enemy speed
    
    Vector3 startPosition; // To store initial position of enemy at start
    
    bool movingRight = true; // To track movement direction
    
    void Awake()
    {
        tc = TimeControl.FindAnyObjectByType<TimeControl>(); // tc is assigned an instance of TimeControl
    }
    
    void Start()
    {
        startPosition = transform.position; // Starting position of enemy
    }
    
    private void Update()
    {
        Patrol(); // Calls Patrol() method
        
        if(tc.timeLeft == 0) // If timer has reached 0
        {
            moveSpeed = 0; // Enemy speed is set to 0
        }
    }
    
    void Patrol()
    {
        float leftBoundary = startPosition.x - moveDistance; // To calculate left movement limit
        float rightBoundary = startPosition.x + moveDistance; // To calculate right movement limit
        
        if(movingRight) // Moving right
        {
            transform.Translate(Vector3.right * moveSpeed * Time.deltaTime); // Moving the enemy right
            
            if(transform.position.x >= rightBoundary) // Checking if reached limit
            {
                movingRight = false; // Move left
            }
        }
        else // Moving left
        {
            transform.Translate(Vector3.left * moveSpeed * Time.deltaTime); // Moving the enemy left
            
            if(transform.position.x <= leftBoundary) // Checking if reached limit
            {
                movingRight = true; // Move right
            }
        }
    }
}