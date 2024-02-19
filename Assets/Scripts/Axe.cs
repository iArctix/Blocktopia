using UnityEngine;

public class Axe : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    void Update()
    {
        // Check if the mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            ActivateAxe();
        }
        else
        {
            DeactivateAxe();
        }
    }

    void ActivateAxe()
    {
        // Trigger the animation
        if (animator != null)
        {
            animator.SetBool("IsActive", true);
        }
    }

    void DeactivateAxe()
    {
        // Stop the animation
        if (animator != null)
        {
            animator.SetBool("IsActive", false);
        }
    }
    
}