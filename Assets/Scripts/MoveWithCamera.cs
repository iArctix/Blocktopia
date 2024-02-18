using UnityEngine;

public class MoveWithCamera : MonoBehaviour
{
    public Vector3 offset = new Vector3(2f, 0f, 2f); // Adjust this offset as needed

    private Camera mainCamera;
    private Quaternion initialLocalRotation;

    void Start()
    {
        mainCamera = Camera.main;
        initialLocalRotation = transform.localRotation; // Store the initial local rotation of the tool
    }

    void Update()
    {
        // Ensure the main camera is not null
        if (mainCamera == null)
        {
            Debug.LogError("Main camera is not assigned!");
            return;
        }

        // Calculate the desired position based on the camera's position and offset
        Vector3 desiredPosition = mainCamera.transform.position + mainCamera.transform.right * offset.x + mainCamera.transform.forward * offset.z + mainCamera.transform.up * offset.y;

        // Update the tool's position
        transform.position = desiredPosition;

        // Calculate the desired rotation based on the camera's rotation and initial local rotation
        Quaternion desiredRotation = Quaternion.LookRotation(mainCamera.transform.forward, mainCamera.transform.up) * initialLocalRotation;

        // Update the tool's rotation
        transform.rotation = desiredRotation;
    }
}