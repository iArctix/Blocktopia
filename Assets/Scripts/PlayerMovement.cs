using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float turnSpeed = 180f;
    public float jumpForce = 8f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded;
    private float verticalRotation = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor at the start
    }

    void Update()
    {
        // Movement
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(moveHorizontal, 0f, moveVertical) * moveSpeed * Time.deltaTime;
        rb.MovePosition(transform.position + transform.TransformDirection(movement));

        // Turning (horizontal rotation)
        float turn = Input.GetAxis("Mouse X") * turnSpeed * Time.deltaTime;
        transform.Rotate(Vector3.up, turn);

        // Looking around (vertical rotation)
        float lookVertical = -Input.GetAxis("Mouse Y") * turnSpeed * Time.deltaTime;
        verticalRotation += lookVertical;
        verticalRotation = Mathf.Clamp(verticalRotation, -90f, 90f); // Limit vertical rotation to prevent flipping
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);

        // Jumping
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump button pressed");
            Debug.Log("Is grounded: " + isGrounded);
            if (isGrounded)
            {
                Debug.Log("Jumping...");
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            }
        }
    }

    void FixedUpdate()
    {
        // Check if the player is grounded
        RaycastHit hit;
        isGrounded = Physics.Raycast(transform.position, Vector3.down, out hit, 2f, groundMask);
        if (isGrounded)
        {
            Debug.Log("Distance to ground: " + hit.distance);
        }
    }
}