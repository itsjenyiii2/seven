using UnityEngine;

public class PickupCollector : MonoBehaviour
{
    public AudioClip pickupSound;
    public AudioSource audioSource;
    // Set this in the Inspector
    public float pickupVolume = 1.0f;

    // Remove AudioSource audioSource; and the Start() method entirely
  

    private void OnCollisionEnter2D(Collision2D col)
    {
        // FIX 1: Change 'gameobject' to 'gameObject'
        // FIX 2: Change '.tag("Player")' to '.tag == "Player"'
        if (col.gameObject.tag == "Player")
        {
            // The rest of the logic seems to assume this script is on the coin,
            // which is why it's destroying 'gameObject'.
            
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            gameObject.GetComponent<Collider2D>().enabled = false;
            
         

            Destroy(gameObject, 1f);
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pickup"))
        {
            // 1. Play the sound at the coin's position (or player's position)
            // This creates a temporary GameObject and AudioSource, plays the sound, and cleans up.
            AudioSource.PlayClipAtPoint(pickupSound, transform.position, pickupVolume);

            // 2. Destroy the pickup item
            Destroy(other.gameObject);
        }
    }

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
} 
// You no longer need an AudioSource component on the Player object for this script.