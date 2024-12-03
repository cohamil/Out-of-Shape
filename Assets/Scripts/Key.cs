using UnityEngine;

public class Key : MonoBehaviour
{
    private FallRespawn fallRespawn; // Reference to the FallRespawn script
    public bool isCollected = false; // Flag to check if the key has been collected
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // get fallRespawn component from player object
        fallRespawn = GameObject.Find("Player").GetComponent<FallRespawn>();
    }

    // This method is called when the player collides with a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object has the specific tag you want to interact with
        if (collision.CompareTag("Player"))
        {
            // Set the player's starting position to the key's position
            fallRespawn.startingPosition = transform.position;
            isCollected = true;
            
            // make the key disappear
            gameObject.SetActive(false);
        }
    }
}
