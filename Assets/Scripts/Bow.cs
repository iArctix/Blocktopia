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