using UnityEngine;

public class FallRespawn : MonoBehaviour
{
    public float fallThreshold = -135f; // The Y position threshold for when the player is considered to have fallen
    public Vector3 startingPosition;    // The position to teleport the player back to

    void Start()
    {
        // Initialize starting position to the player's initial position if not set in Inspector
        if (startingPosition == Vector3.zero)
        {
            startingPosition = transform.position;
        }
    }

    void Update()
    {
        // Check if player has fallen below the fall threshold
        if (transform.position.y < fallThreshold)
        {
            Respawn();
        }
    }

    public void Respawn()
    {
        // Teleport the player back to the starting position
        transform.position = startingPosition;
    }
}
