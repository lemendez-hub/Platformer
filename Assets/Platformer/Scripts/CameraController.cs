using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform player;
    private Vector3 offset;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position - player.transform.position; // Calculate the initial offset between the camera and the player
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.transform.position + offset; // Update the camera's position to follow the player while maintaining the offset
    }
}
