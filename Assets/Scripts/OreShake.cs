using UnityEngine;

public class OreShake : MonoBehaviour
{
    private Vector3 originalPosition; // Store the original position of the ore object
    private bool shaking = false; // Flag to track if the ore is currently shaking
    private float shakeSpeed = 10f; // Speed of the shake
    private float shakeAmount = 0.1f; // Intensity of the shake

    void Start()
    {
        // Store the original position of the ore object
        originalPosition = transform.position;
    }

    void Update()
    {
        if (shaking)
        {
            // Calculate the amount of shake based on time
            float shakeOffsetX = Mathf.Sin(Time.time * shakeSpeed) * shakeAmount;
            float shakeOffsetY = Mathf.Sin(Time.time * shakeSpeed * 1.2f) * shakeAmount; // Offset Y shaking for variety

            // Apply the shake offset to the ore object's position
            transform.position = originalPosition + new Vector3(shakeOffsetX, shakeOffsetY, 0f);
        }
    }

    public void StartShaking(float speed, float amount)
    {
        shakeSpeed = speed;
        shakeAmount = amount;
        shaking = true;
    }

    public void StopShaking()
    {
        shaking = false;
        // Reset the position of the ore object to its original position when shaking stops
        transform.position = originalPosition;
    }
}