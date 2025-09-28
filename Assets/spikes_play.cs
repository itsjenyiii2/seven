using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 initialSpawnPosition; 
    public GameObject explosionPrefab; 

    void Start()
    {
        initialSpawnPosition = transform.position;
    }

    public float respawnDelay = 0.5f;

void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
        
    
            GetComponent<Renderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;

            StartCoroutine(ExplosionAndRespawn());
        }
    }

    private IEnumerator ExplosionAndRespawn()
    {
        // 1. Particle spawning logic is now removed from here.

        // 2. Wait for the visual effect to play out
        yield return new WaitForSeconds(respawnDelay);

        // 3. Teleport and Reset Physics (Respawn)
        transform.position = initialSpawnPosition;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero; // Use .velocity
            rb.angularVelocity = 0f;
        }

        // 4. Re-enable the player
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
    
}
