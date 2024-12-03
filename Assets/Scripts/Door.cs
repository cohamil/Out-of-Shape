using UnityEngine;

public class Door : MonoBehaviour
{
    private Key key; // Reference to the Key script
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        key = GameObject.Find("Key").GetComponent<Key>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // This method is called when the player collides with the door
    private  void OnCollisionEnter2D(Collision2D other) {
        // Check if the object has the specific tag you want to interact with
        if (other.gameObject.CompareTag("Player"))
        {
            // Check if the key has been collected
            if (key.isCollected)
            {
                // make the door disappear
                gameObject.SetActive(false);
            }
        }
    }
}
