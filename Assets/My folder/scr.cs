using UnityEngine;

public class cotroler : MonoBehaviour
{
    float horizontalInput;
    float Speed = 5f;
    bool isFacingLeft = false;
    float Jumpower = 6f;
    bool isJumping = false;

    Rigidbody2D rb;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();

        if (Input.GetButtonDown("Jump") && !isJumping)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Jumpower);
            isJumping = true;
        }
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(horizontalInput * Speed, rb.linearVelocity.y);
    }

    void FlipSprite()
    {
        if (isFacingLeft && horizontalInput < 0f || !isFacingLeft && horizontalInput > 0f)
        {
            isFacingLeft = !isFacingLeft;
            Vector3 ls = transform.localScale;
            ls.x *= -1f;
            transform.localScale = ls;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isJumping = false;
    }

}