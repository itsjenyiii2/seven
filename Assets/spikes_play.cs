using UnityEngine;
using System.Collections;

//puuzita AI
public class PlayerMovement : MonoBehaviour
{
    private Vector3 checkpointPos;
    public GameObject explosionPrefab;

    void Start()
    {
        checkpointPos = transform.position;
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
        yield return new WaitForSeconds(respawnDelay);

        transform.position = checkpointPos;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.angularVelocity = 0f;
        }

        // 4. Re-enable the player
        GetComponent<Renderer>().enabled = true;
        GetComponent<Collider2D>().enabled = true;
    }
    
    public void UpdateCheckpoint(Vector3 pos)
    {
        checkpointPos = pos;
    }   

}
