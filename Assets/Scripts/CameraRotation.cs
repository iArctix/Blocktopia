using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public float sensitivity = 100f;
    public float verticalClampAngle = 90f;

    private float mouseX;
    private float mouseY;
    private float verticalRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        transform.parent.Rotate(Vector3.up * mouseX);

        // Calculate vertical rotation
        verticalRotation -= mouseY;
        verticalRotation = Mathf.Clamp(verticalRotation, -verticalClampAngle, verticalClampAngle);

        // Apply rotation
        transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);
    }
}