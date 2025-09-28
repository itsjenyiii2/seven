using UnityEngine;
//AI-generated script to handle the pedestal and wall interaction in a 2D Unity game.
// This script should be attached to the "Pedestal" GameObject.
public class pedestal : MonoBehaviour
{
    // --- Public Variables for Unity Editor Setup ---

    [Tooltip("The specific object (the 'Wall') that will disappear when activated.")]
    public GameObject blockingWall;

    [Tooltip("The Tag of the object that needs to be placed on the pedestal (e.g., 'ActivationBall').")]
    public string requiredTag = "ActivationBall";

    // --- Private State Variable ---
    private bool isWallRemoved = false;


    // --- Unity Setup Instructions (IMPORTANT!) ---
    /*
    1.  PEDESTAL OBJECT:
        -   Create an empty GameObject (or use a Sprite) and name it 'Pedestal'.
        -   Attach this 'WallActivator.cs' script to it.
        -   Add a Collider2D (e.g., BoxCollider2D) that covers the area where the ball should sit.
        -   Crucially, CHECK THE 'Is Trigger' BOX on the Pedestal's Collider2D.

    2.  BALL OBJECT:
        -   Create your 'Ball' GameObject (Sprite/Circle).
        -   Add a Collider2D (e.g., CircleCollider2D). DO NOT check 'Is Trigger'.
        -   Add a Rigidbody2D component so it can be moved by physics (gravity, player interaction).
        -   Set the 'Tag' of the Ball object in the Inspector to match the 'requiredTag' in the script (default is 'ActivationBall').

    3.  WALL OBJECT:
        -   Create your 'BlockingWall' GameObject (Sprite/Tilemap).
        -   Ensure it has a Collider2D so the player can't walk through it.
        -   Drag this Wall object into the 'Blocking Wall' slot on the 'Pedestal' in the Inspector.

    4.  INITIAL STATE:
        -   In the Unity Editor, make sure the 'BlockingWall' GameObject is INITIALLY ACTIVATED (checked in the Inspector) so it is visible and blocking the path at the start of the game.
    */


    void Start()
    {
        // Safety check to ensure the wall reference is set.
        if (blockingWall == null)
        {
            Debug.LogError("WallActivator: The 'Blocking Wall' field is not assigned in the Inspector!", this);
            return;
        }

        // Ensure the wall starts in the blocking state.
        blockingWall.SetActive(true);
        isWallRemoved = false;
    }

    /// <summary>
    /// Called when another Collider2D enters the Pedestal's trigger zone.
    /// </summary>
    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered the trigger has the correct tag (the ball).
        if (other.CompareTag(requiredTag))
        {
            // Only proceed if the object has physics (is movable, like a Rigidbody2D).
            if (other.GetComponent<Rigidbody2D>() != null)
            {
                RemoveWall();
            }
        }
    }

    /// <summary>
    /// Called when a Collider2D exits the Pedestal's trigger zone.
    /// </summary>
    private void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object that exited was the ball.
        if (other.CompareTag(requiredTag))
        {
            // Only proceed if the object has physics (is movable, like a Rigidbody2D).
            if (other.GetComponent<Rigidbody2D>() != null)
            {
                RestoreWall();
            }
        }
    }

    /// <summary>
    /// Deactivates the blocking wall, opening the path.
    /// </summary>
    private void RemoveWall()
    {
        if (!isWallRemoved)
        {
            Debug.Log("Activation Ball placed! Wall disappears.");
            blockingWall.SetActive(false);
            isWallRemoved = true;
        }
    }

    /// <summary>
    /// Re-activates the blocking wall, closing the path.
    /// </summary>
    private void RestoreWall()
    {
        if (isWallRemoved)
        {
            Debug.Log("Activation Ball removed! Wall restores itself.");
            blockingWall.SetActive(true);
            isWallRemoved = false;
        }
    }
}
