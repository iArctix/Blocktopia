using UnityEngine;

public class Axe : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public float reachDistance = 3f; // Adjust this value to change how far the player can interact with objects
    public float choppingTime = 3f; // Time it takes to chop the wood

    bool isChopping = false; // Flag to track if the player is currently chopping
    float choppingTimer = 0f; // Timer for chopping duration

    void Update()
    {
        // Check if the mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            // If not currently chopping, start chopping
            if (!isChopping)
            {
                StartChopping();
            }
            else
            {
                // Increment chopping timer
                choppingTimer += Time.deltaTime;

                // Check if chopping time is reached
                if (choppingTimer >= choppingTime)
                {
                    CompleteChopping();
                }
            }
        }
        else
        {
            // If player releases mouse button, stop chopping
            if (isChopping)
            {
                StopChopping();
            }
        }
    }

    void StartChopping()
    {
        // Trigger the animation
        if (animator != null)
        {
            animator.SetBool("IsActive", true);
        }

        // Set chopping flag to true
        isChopping = true;
    }

    void CompleteChopping()
    {
        // Perform raycasting to detect wood again
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, reachDistance))
        {
            if (hit.collider.CompareTag("Wood"))
            {
                // Destroy the wood GameObject
                Destroy(hit.collider.gameObject);
            }
        }

        // Reset chopping variables
        StopChopping();
    }

    void StopChopping()
    {
        // Stop the animation
        if (animator != null)
        {
            animator.SetBool("IsActive", false);
        }

        // Reset chopping variables
        isChopping = false;
        choppingTimer = 0f;
    }
}