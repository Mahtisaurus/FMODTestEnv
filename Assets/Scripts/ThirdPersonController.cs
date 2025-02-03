using UnityEngine;

public class ThirdPersonController : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float rotationSpeed = 720f;
    public float gravity = -9.81f;

    private CharacterController characterController;
    private Vector3 verticalVelocity;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        // Warn if no CharacterController is attached.
        if (characterController == null)
        {
            Debug.LogError("ThirdPersonController: No CharacterController found on " + gameObject.name);
        }
    }

    void Update()
    {
        // Get input from keyboard
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // Build a movement vector in the XZ plane
        Vector3 moveDirection = new Vector3(horizontal, 0, vertical);

        // Only move if there's input (magnitude > threshold)
        if (moveDirection.magnitude >= 0.1f)
        {
            // Determine target rotation based on movement direction
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            // Move the character (ignoring gravity for now)
            characterController.Move(moveDirection * moveSpeed * Time.deltaTime);
        }

        // Apply gravity
        if (characterController.isGrounded)
        {
            verticalVelocity.y = 0;
        }
        verticalVelocity.y += gravity * Time.deltaTime;
        characterController.Move(verticalVelocity * Time.deltaTime);
    }

    // Detect if the player collides with a collectable object.
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collectable"))
        {
            Debug.Log("Collected a collectable: " + other.gameObject.name);
            // Optionally, add more functionality here (e.g., update score)
        }
    }
}
