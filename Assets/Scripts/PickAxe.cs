using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public float reachDistance = 3f; // Adjust this value to change how far the player can interact with objects
    public float miningTime = 3f; // Time it takes to mine the ore

    bool isMining = false; // Flag to track if the player is currently mining
    float miningTimer = 0f; // Timer for mining duration

    void Update()
    {
        // Check if the mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            // If not currently mining, start mining
            if (!isMining)
            {
                animator.SetBool("IsActive", true); // Trigger the pickaxe animation
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, reachDistance))
                {
                    if (hit.collider.CompareTag("Ore"))
                    {
                        isMining = true;
                    }
                }
            }
            else
            {
                // Increment mining timer
                miningTimer += Time.deltaTime;

                // Check if mining time is reached
                if (miningTimer >= miningTime)
                {
                    CompleteMining();
                }
            }
        }
        else
        {
            // If player releases mouse button, stop mining
            if (isMining)
            {
                animator.SetBool("IsActive", false); // Stop the pickaxe animation
                isMining = false;
                miningTimer = 0f;
            }
        }
    }

    void CompleteMining()
    {
        // Perform raycasting to detect ore again
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, reachDistance))
        {
            if (hit.collider.CompareTag("Ore"))
            {
                // Destroy the ore GameObject
                Destroy(hit.collider.gameObject);
            }
        }

        // Reset mining variables
        animator.SetBool("IsActive", false); // Stop the pickaxe animation
        isMining = false;
        miningTimer = 0f;
    }
}
