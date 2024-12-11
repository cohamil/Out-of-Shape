using UnityEngine;

public class Ghost : MonoBehaviour
{
    private GameObject player; // Reference to the player object
    private FallRespawn fallRespawn; // Reference to the FallRespawn script
    public Vector3 startingPosition;

    [SerializeField] private float speed = 2f; // The speed at which the ghost chases the player
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player");
        fallRespawn = player.GetComponent<FallRespawn>();
        // Initialize starting position to the player's initial position if not set in Inspector
        if (startingPosition == Vector3.zero)
        {
            startingPosition = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Chase the player
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        // Make sure the sprite is facing the player
        if (player.transform.position.x < transform.position.x)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }

    }

    public void RespawnGhost()
    {
        // Teleport the player back to the starting position
        transform.position = startingPosition;
    }

    // This method is called when the player collides with the ghost
    private void OnTriggerEnter2D(Collider2D collision) {
        // Check if the object has the specific tag you want to interact with
        if (collision.CompareTag("Player"))
        {
            fallRespawn.Respawn();
            RespawnGhost();
        }
    }

    public void setSpeed (float speed){
        this.speed = 0f;
    }
}
