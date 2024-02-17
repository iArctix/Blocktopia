using UnityEngine;

public class Arrow : MonoBehaviour
{
    public float lifetime = 10f; // Lifetime of the arrow in seconds
    public bool isStuck = false; // Indicates if the arrow is stuck in an object

    void Start()
    {
        // Destroy the arrow after the specified lifetime
        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the arrow collides with something other than the player
        if (collision.gameObject.tag != "Player")
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