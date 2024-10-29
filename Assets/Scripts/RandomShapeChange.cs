using UnityEngine;

public class RandomShapeChange : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite[] sprites;

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
        if (collision.CompareTag("ShapeChangeTrigger"))
        {
            // Generate a random sprite from the sprites array
            Sprite newSprite = sprites[Random.Range(0, sprites.Length)];
            // Assign the new sprite to the player's sprite renderer
            spriteRenderer.sprite = newSprite;
        }
    }
}
