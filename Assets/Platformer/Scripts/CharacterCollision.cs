using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterCollision : MonoBehaviour
{
    
    void OnControllerColliderHit(ControllerColliderHit collision)
    {
        if (collision.gameObject.CompareTag("Brick") && Keyboard.current.spaceKey.isPressed) // If the player is colliding with a brick and the space key is pressed, destroy the brick
        {
            Destroy(collision.gameObject); // Destroy the brick
        }

        if (collision.gameObject.CompareTag("Question") && Keyboard.current.spaceKey.isPressed) // If the player is colliding with a question block and the space key is pressed, increase coin count
        {
            CoinTracker.FindAnyObjectByType<CoinTracker>().coinCount++; // Increase the coin count in the ScoreControl
        }
    }
}