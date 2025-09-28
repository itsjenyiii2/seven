using UnityEngine;
using System.Collections;

public class moving : MonoBehaviour
{
    public Transform pos1, pos2;
    public float speed = 3f;           // Use this public speed variable
    public float waitDuration = 1f;    // Use this public duration variable
    
    private Vector3 targetPos;
    private bool isWaiting = false;    // State variable to prevent re-starting the coroutine

    private void Start()
    {
        // Set the initial target
        targetPos = pos2.position;
    }

    private void Update()
    {
        // 1. Check if the object is NOT currently waiting
        if (!isWaiting)
        {
            // Move the object
            transform.position = Vector3.MoveTowards(
                transform.position, 
                targetPos, 
                speed * Time.deltaTime // Use the public 'speed' variable
            );

            // 2. Check if the object has reached a point (within a small tolerance)
            if (Vector3.Distance(transform.position, targetPos) < 0.01f)
            {
                // We reached the target, now start the wait coroutine
                StartCoroutine(WaitNextPoint());
            }
        }
        // Note: The movement and target switching logic is now contained within the coroutine.
    }

    IEnumerator WaitNextPoint()
    {
        // Set the flag to true to STOP the movement in Update()
        isWaiting = true;
        
        // Wait for the specified duration
        yield return new WaitForSeconds(waitDuration);

        // After waiting, switch the target position
        if (targetPos == pos1.position)
        {
            targetPos = pos2.position;
        }
        else
        {
            targetPos = pos1.position;
        }

        // Set the flag to false to RE-START the movement in Update()
        isWaiting = false;
    }
}
