using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 500f;
    public float sensitivity = 2f;
    public float jumpForce = 12f;
    private Rigidbody rb;
    private float rotationX = 0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Player movement
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movement = (transform.right * horizontalInput + transform.forward * verticalInput) * speed * Time.deltaTime;
        rb.velocity = new Vector3(movement.x, rb.velocity.y, movement.z);

        // Player rotation with mouse
        float mouseX = Input.GetAxis("Mouse X") * sensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity;
        rotationX -= mouseY;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);
        transform.localRotation = Quaternion.Euler(rotationX, transform.localEulerAngles.y + mouseX, 0f);

        // Player jump
        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private bool IsGrounded()
    {
        RaycastHit hit;
        float distance = GetComponent<Collider>().bounds.extents.y + 0.1f;
        return Physics.Raycast(transform.position, Vector3.down, out hit, distance);
    }
}
