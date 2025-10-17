using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Movement")]
    private float inputX;
    [SerializeField] private bool isRunning = false;
    [SerializeField] private float horizontalSpeed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private int jumpsRemaining;
    [SerializeField] private bool isGrounded;

    private Rigidbody2D rb;
    [Header("Ground Check")]
    [SerializeField] private Transform groundCheck;
    [SerializeField] private Vector2 groundCheckSize = new Vector2(0.2f, 0.2f);
    [SerializeField] private LayerMask groundLayer;
    [Header("Gravity Modifier")]
    [SerializeField] private float baseGravity = 2f;
    [SerializeField] private float maxFallSpeed = 18f;
    [SerializeField] private float fallSpeedmodifier = 2f;




    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement();
        Jump();

        if (!isGrounded) // if not on ground then check for ground and change gravity
        {
            GroundCheck();
            Gravity();
        }

    }
    private void Gravity()
    {
        if (rb.linearVelocityY < 0) // if falling
        {
            rb.gravityScale = baseGravity * fallSpeedmodifier; // change gravity
            rb.linearVelocity = new Vector2(rb.linearVelocityX, Mathf.Max(rb.linearVelocityY, -maxFallSpeed)); // slowly decrease velocity and stops at -maxFallSpeed
        }
        else
        {
            rb.gravityScale = baseGravity; // else set gravity to normal
        }
    }

    private void HorizontalMovement()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        isRunning = Input.GetKey("left shift");

        if (isRunning)
        {
            rb.linearVelocity = new Vector2(inputX * horizontalSpeed * 1.25f, rb.linearVelocityY);
        }
        else
        rb.linearVelocity = new Vector2(inputX * horizontalSpeed, rb.linearVelocityY);
    }

    private void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            if (jumpsRemaining > 0) // double jump condition
            {
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpSpeed);
                jumpsRemaining--;
                isGrounded = false;
            }
        }

        if (Input.GetKeyUp("space") && !isGrounded)
        {
            if (jumpsRemaining > 0)
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpSpeed / 2);
        }

    }

    private void GroundCheck()
    {
        bool hitGround = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundLayer); //if groundcheck overlaps with ground layer

        if (hitGround && rb.linearVelocityY <= 0.1f) // if on ground and Velocity Y is close to 0. dont use == 0 as floating values can be slightly different
        {
            jumpsRemaining = maxJumps;
            isGrounded = true;
        }
        else
        {
            isGrounded = false; // Velocity Y is in negative
        }
    }


    void OnDrawGizmosSelected() // to visualize ground check box.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }

    public void Test()
    {
        
    }
}

