using UnityEngine;

public class Bow : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float minArrowSpeed = 5f;
    public float maxArrowSpeed = 50f;
    public float chargeTimeToMaxSpeed = 2f;
    public float arrowGravity = 9.81f; // Acceleration due to gravity
    public float fireCooldown = 0.4f; // Cooldown duration in seconds

    private bool isCharging;
    private float chargeStartTime;
    private float lastFireTime; // Time when the last arrow was fired

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && Time.time - lastFireTime >= fireCooldown) // Check if cooldown is over
        {
            isCharging = true;
            chargeStartTime = Time.time;
        }

        if (Input.GetMouseButtonUp(0) && isCharging)
        {
            isCharging = false;
            FireArrow();
            lastFireTime = Time.time; // Update last fire time
        }
    }

    void FireArrow()
    {
        float chargeTime = Time.time - chargeStartTime;
        chargeTime = Mathf.Min(chargeTime, chargeTimeToMaxSpeed);
        float speedRatio = chargeTime / chargeTimeToMaxSpeed;
        float arrowSpeed = Mathf.Lerp(minArrowSpeed, maxArrowSpeed, speedRatio);

        Vector3 spawnPosition = Camera.main.transform.position;

        GameObject arrowObject = Instantiate(arrowPrefab, spawnPosition, Quaternion.identity);
        Rigidbody arrowRigidbody = arrowObject.GetComponent<Rigidbody>();

        Vector3 direction = Camera.main.transform.forward.normalized;
        float initialVelocityY = (arrowSpeed * Mathf.Sin(45 * Mathf.Deg2Rad)) / (Mathf.Cos(45 * Mathf.Deg2Rad) * arrowGravity);
        float initialVelocityXZ = arrowSpeed / Mathf.Cos(45 * Mathf.Deg2Rad);
        arrowRigidbody.velocity = direction * initialVelocityXZ + Vector3.up * initialVelocityY;
        arrowObject.transform.rotation = Quaternion.LookRotation(direction);
        arrowRigidbody.angularVelocity = arrowObject.transform.forward * arrowSpeed;
    }
}