using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            spriteRenderer.color = Color.red;
        }

        if (Input.GetKeyDown(KeyCode.G))
        {
            spriteRenderer.color = Color.green;
        }
        if (Input.GetKeyDown(KeyCode.B))
        {
            spriteRenderer.color = Color.blue;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            spriteRenderer.color = Color.white;
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            spriteRenderer.color = Color.yellow;
        }   
    }
}
