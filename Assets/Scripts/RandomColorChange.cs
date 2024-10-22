using UnityEngine;

public class RandomColorChange : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        // Get the SpriteRenderer component attached to the player object
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // This method is called when the player collides with a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object has the specific tag you want to interact with
        if (collision.CompareTag("ColorChangeTrigger"))
        {
            // Generate a random color
            Color newColor = new Color(Random.value, Random.value, Random.value);
            // Assign the new color to the player's sprite renderer
            spriteRenderer.color = newColor;
        }
    }
}
