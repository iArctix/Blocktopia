using UnityEngine;
using System.Collections;

public class Sword : MonoBehaviour
{
    public Animator animator;
    public float damage = 20f;
    public Playerstats stats;
    public float range = 1f;
    private bool hitRegistered = false;
    public float hitDelay = 1f; // Delay in seconds before another hit can occur

    void Update()
    {
        // Check if the mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            ActivateSword();
            if (!hitRegistered)
            {
                CheckForHit();
            }
        }
        else
        {
            DeactivateSword();
        }
    }

    void ActivateSword()
    {
        // Trigger the animation
        if (animator != null)
        {
            animator.SetBool("IsActive", true);
        }
    }

    void DeactivateSword()
    {
        // Stop the animation
        if (animator != null)
        {
            animator.SetBool("IsActive", false);
        }
    }

    void CheckForHit()
    {
        // Cast a ray forward from the sword
        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, range))
        {
            // Check if the ray hit an enemy
            if (hit.collider.CompareTag("Enemy"))
            {
                // Get the EnemyController component of the collided enemy
                EnemyController enemyController = hit.collider.GetComponent<EnemyController>();
                if (enemyController != null)
                {
                    // Deal damage to the enemy
                    enemyController.TakeDamage(damage + stats.Strengthlevel);
                    hitRegistered = true; // Set hitRegistered to true to prevent further damage in this swing
                    StartCoroutine(ResetHit());
                }
            }
        }
    }

    IEnumerator ResetHit()
    {
        yield return new WaitForSeconds(hitDelay);
        hitRegistered = false; // Reset hitRegistered after the delay
    }
}