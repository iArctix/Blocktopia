using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifetime = 10f; // Lifetime of the arrow in seconds
    public float damage = 10f; // Amount of damage the arrow deals
    public bool isStuck = false; // Indicates if the arrow is stuck in an object

    void Start()
    {
        // Destroy the arrow after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the arrow collides with an enemy
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Get the EnemyController component of the collided enemy
            EnemyController enemyController = collision.gameObject.GetComponent<EnemyController>();
            if (enemyController != null)
            {
                // Deal damage to the enemy
                enemyController.TakeDamage(damage);
            }

            // Destroy the arrow upon collision with an enemy
            Destroy(gameObject);
        }
        // Check if the arrow collides with something other than the player
        else if (collision.gameObject.CompareTag("Environment"))
        {
            // Set the arrow to be stuck in the object it collided with
            isStuck = true;

            // Disable the arrow's Rigidbody to prevent it from moving
            Rigidbody arrowRigidbody = GetComponent<Rigidbody>();
            if (arrowRigidbody != null)
            {
                arrowRigidbody.isKinematic = true;
            }

            // Parent the arrow to the object it collided with
            transform.parent = collision.transform;
        }
    }
}