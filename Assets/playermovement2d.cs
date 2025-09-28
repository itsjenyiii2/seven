using UnityEngine;

public class playermovement2d : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    public CharacterController2D controller;
    public Animator animator;


    float horizontalMove = 0f;
    public float runSpeed = 40f;
    bool jump = false;
    // Update is called once per frame
    void Update()
    {


        horizontalMove = Input.GetAxis("Horizontal") * runSpeed;
        animator.SetFloat("speed", Mathf.Abs(horizontalMove));


        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("Jumping", true);
        }
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Candy"))
        {
            Destroy(other.gameObject);
        }

    }
    public void OnLanding()
    {
        animator.SetBool("Jumping", false);
    }
    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

}
