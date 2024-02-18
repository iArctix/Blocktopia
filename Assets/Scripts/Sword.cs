using UnityEngine;

public class Sword : MonoBehaviour
{
    public float damage = 20f; // Amount of damage the sword deals
    public Animator animator; // Reference to the Animator component

    void Update()
    {
        // Check for mouse click to swing the sword
        if (Input.GetMouseButtonDown(0))
        {
            SwingSword();
        }
    }

    void SwingSword()
    {
        // Trigger the "Active" parameter to transition to the "SwordAnim" state
        if (animator != null)
        {
            animator.SetTrigger("Active");
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
                enemyController.TakeDamage(damage);
            }
        }
    }
}
