using UnityEngine;

public class SignInteract : MonoBehaviour
{
    //private Transform player;
    public MeshRenderer speechBubbleRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (speechBubbleRenderer != null){
            speechBubbleRenderer.enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            speechBubbleRenderer.enabled = true;
            //Debug.Log("player entered range");
        }
        //player = collision.gameObject.GetComponent<Transform>();
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.tag == "Player"){
            speechBubbleRenderer.enabled = false;
        }
    }

}

// Detect Player
// Add trigger collision -> turn color when close?
// if player is in collider, press 'e' to display message
// when player leaves collider, turn off display message if it is on
