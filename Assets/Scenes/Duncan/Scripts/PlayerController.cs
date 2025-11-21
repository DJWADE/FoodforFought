using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController2_5D : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 6f;
    public float jumpForce = 7f;

    [Header("Ground Check")]
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public LayerMask groundMask;

    private Rigidbody rb;
    private bool isGrounded;

    private Vector2 moveInput;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        // Ground check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log($"Grounded: {isGrounded}");

        // Input
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Jump button pressed");
        }

        moveInput.x = Input.GetAxisRaw("Horizontal");
        moveInput.y = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            Jump();
        }
    }

    void FixedUpdate()
    {
        Move();

        if (rb.linearVelocity.y > 0)
        {
            rb.AddForce(Physics.gravity * 2f, ForceMode.Acceleration);
        }
        else if (rb.linearVelocity.y < 0)
        {
            rb.AddForce(Physics.gravity * 5f, ForceMode.Acceleration);
        }
    }



    void Move()
    {
        Vector3 move = new Vector3(moveInput.x, 0, moveInput.y).normalized;
        Vector3 velocity = move * moveSpeed;
        Vector3 newVelocity = new Vector3(velocity.x, rb.linearVelocity.y, velocity.z);

        rb.linearVelocity = newVelocity;
    }

    void Jump()
    {
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnDrawGizmosSelected()
    {
        if (groundCheck != null)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(groundCheck.position, groundDistance);
        }
    }
}