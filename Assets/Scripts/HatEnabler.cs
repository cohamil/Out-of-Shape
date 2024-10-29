using UnityEngine;

public class HatEnabler : MonoBehaviour
{
    [SerializeField] private GameObject hat;

    // This method is called when the player collides with a trigger collider
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object has the specific tag you want to interact with
        if (collision.CompareTag("HatTrigger"))
        {
            if (hat.activeSelf) hat.SetActive(false);
            else hat.SetActive(true);
        }
    }
}
