using UnityEngine;

public class Pickaxe : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    void Update()
    {
        // Check if the mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            ActivatePickaxe();
        }
        else
        {
            DeactivatePickaxe();
        }
    }

    void ActivatePickaxe()
    {
        // Trigger the animation
        if (animator != null)
        {
            animator.SetBool("IsActive", true);
        }
    }

    void DeactivatePickaxe()
    {
        // Stop the animation
        if (animator != null)
        {
            animator.SetBool("IsActive", false);
        }
    }
}
