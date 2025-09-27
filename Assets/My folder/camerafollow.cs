using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public float FollowSpeed = 2f;
    public float yOffset = 1f;
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        Vector3 newPos = new Vector3(target.position.x, target.position.y + yOffset, -10f);
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}

public class Move : MonoBehaviour
{
    private Rigidbody2D rb;
    public float dirX, dirY, moveSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5f;

    }
    void Update()
    {
        dirX = Input.GetAxis("Horizontal") * moveSpeed;
        dirY = Input.GetAxis("Vertical") * moveSpeed;
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dirX, dirY);
    }

    public class CameraClamp : MonoBehaviour
    {
        private Transform targetToFollow;
 void Update()
        {
            transform.position = new Vector3(
                Mathf.Clamp(targetToFollow.position.x, -12f, 1.5f),
                Mathf.Clamp(targetToFollow.position.y, 9f, 1.4f),
                transform.position.z);
        }
    }
}