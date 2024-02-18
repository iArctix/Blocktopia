using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float minArrowSpeed = 2f;
    public float maxArrowSpeed = 30f;
    public float chargeTimeToMaxSpeed = 2f;
    public float arrowGravity = 9.81f; // Acceleration due to gravity

    private bool isCharging;
    private float chargeStartTime;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Change the button if needed
        {
            isCharging = true;
            chargeStartTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0) && isCharging)
        {
            isCharging = false;
            FireArrow();
        }
    }

    void FireArrow()
    {
        // Calculate charge time
        float chargeTime = Time.time - chargeStartTime;

        // Limit charge time to max charge time
        chargeTime = Mathf.Min(chargeTime, chargeTimeToMaxSpeed);

        // Calculate arrow speed based on charge time
        float speedRatio = chargeTime / chargeTimeToMaxSpeed;
        float arrowSpeed = Mathf.Lerp(minArrowSpeed, maxArrowSpeed, speedRatio);

        // Set arrow spawn position to the player's position
        Vector3 spawnPosition = transform.position; // Assuming the bow is parented to the player

        GameObject arrowObject = Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);
        Rigidbody arrowRigidbody = arrowObject.GetComponent<Rigidbody>();

        // Fire the arrow in the direction the player is looking
        Vector3 direction = Camera.main.transform.forward.normalized;

        // Calculate the initial upward velocity to achieve an arc trajectory
        float initialVelocityY = (arrowSpeed * Mathf.Sin(45 * Mathf.Deg2Rad)) / (Mathf.Cos(45 * Mathf.Deg2Rad) * arrowGravity);

        // Calculate the initial forward velocity
        float initialVelocityXZ = arrowSpeed / Mathf.Cos(45 * Mathf.Deg2Rad);

        // Set initial velocity
        arrowRigidbody.velocity = direction * initialVelocityXZ + Vector3.up * initialVelocityY;

        // Rotate the arrow to face its direction of travel
        arrowObject.transform.rotation = Quaternion.LookRotation(direction);

        // Apply spin to the arrow along its forward axis
        arrowRigidbody.angularVelocity = arrowObject.transform.forward * arrowSpeed;
    }
}