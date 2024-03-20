using UnityEngine;

public class Sword : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component
    public float damage = 20f;
    public Playerstats stats;

    void Update()
    {
        // Check if the mouse button is being held down
        if (Input.GetMouseButton(0))
        {
            ActivateSword();
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
    void OnCollisionEnter(Collision collision)
    {
        // Check if the sword collides with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get the EnemyController component of the collided enemy
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                // Deal damage to the enemy
                enemyController.TakeDamage(damage + stats.Strengthlevel);
            }
        }
    }
}