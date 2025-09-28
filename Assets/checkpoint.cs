using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private PlayerMovement PlayerMovement;
    private void Awake()
    {
        PlayerMovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerMovement.UpdateCheckpoint (transform.position);
        
        }
    }
}
