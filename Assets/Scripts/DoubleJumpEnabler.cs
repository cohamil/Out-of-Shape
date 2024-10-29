using UnityEngine;

public class DoubleJumpEnabler : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;

    // This method is called when the player collides with a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object has the specific tag you want to interact with
        if (collision.CompareTag("DoubleJumpTrigger"))
        {
            // Enable double jump in the player controller
            playerController.doubleJumpEnabled = true;
        }
    }
}
