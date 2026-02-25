using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player; // Reference to player's transform so camera can follow
    
    float offsetX; // To store horizontal distance between camera and player
    float fixedY; // To store camera's y-pos
    float fixedZ; // To store camera's z-pos
    
    void Start()
    {
        offsetX = transform.position.x - player.position.x; // Calculates initial horizontal offset
        fixedY = transform.position.y; // Saves the camera's starting y-pos, stays fixed
        fixedZ = transform.position.z; // Saves the camera's starting z-pos, stays fixed
    }
    
    void Update()
    {
        transform.position = new Vector3(player.position.x + offsetX, fixedY, fixedZ); // Updates the camera's position
    }
}