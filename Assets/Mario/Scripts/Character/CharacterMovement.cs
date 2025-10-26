using UnityEngine;
using UnityEngine.Events;

public class CharacterMovement : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
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
    //Animation STUFF
    private CharacterAnimatorManager animator;
    private const string MOVE_X = "MoveX";
    private const string MOVE_Y = "MoveY";
    private const string IS_MOVING = "IsMoving";
    private const string IS_GROUNDED = "IsGrounded";
    private const string DOUBLE_JUMP = "DoubleJump";


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        jumpsRemaining = maxJumps;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<CharacterAnimatorManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (PauseManager.instance.isPlayerPaused)
        {
            rb.gravityScale = 0;
            rb.linearVelocity = Vector2.zero;
            return;
        }


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
            animator.SetFloat(MOVE_Y, -1);
        }
        else
        {
            rb.gravityScale = baseGravity; // else set gravity to normal
        }
    }

    public float LastXInput = 0;
    private void HorizontalMovement()
    {
        inputX = Input.GetAxisRaw("Horizontal");
        isRunning = Input.GetKey("left shift");

        if (LastXInput != inputX && inputX != 0)
        {
            LastXInput = inputX;
        }

        FlipFace();

        if (inputX != 0)
        {
            animator.SetBoolTrue(IS_MOVING);
            animator.SetFloat(MOVE_X, inputX);
        }
        else
        {
            animator.SetBoolFalse(IS_MOVING);
        }

        if (isRunning)
        {
            rb.linearVelocity = new Vector2(inputX * horizontalSpeed * 1.25f, rb.linearVelocityY);
        }
        else
        {
            rb.linearVelocity = new Vector2(inputX * horizontalSpeed, rb.linearVelocityY);
        }

    }

    private void FlipFace()
    {
        if (LastXInput > 0)
        {
            // spriteRenderer.flipX = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (LastXInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
            // spriteRenderer.flipX = true;
        }
    }

    private void Jump()
    {
        if (Input.GetKeyDown("space"))
        {
            if (jumpsRemaining > 0) // double jump condition
            {
                if (jumpsRemaining == 1)
                { animator.SetTrigger(DOUBLE_JUMP); }

                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpSpeed);
                jumpsRemaining--;
                isGrounded = false;
                animator.SetBoolFalse(IS_GROUNDED);
                animator.SetFloat(MOVE_Y, 1);

            }
        }

        if (Input.GetKeyUp("space") && !isGrounded)
        {
            if (jumpsRemaining > 0)
                rb.linearVelocity = new Vector2(rb.linearVelocityX, jumpSpeed * 0.75f);
        }

    }

    private void GroundCheck()
    {
        bool hitGround = Physics2D.OverlapBox(groundCheck.position, groundCheckSize, 0, groundLayer); //if groundcheck overlaps with ground layer

        if (hitGround && rb.linearVelocityY <= 0.1f) // if on ground and Velocity Y is close to 0. dont use == 0 as floating values can be slightly different
        {
            jumpsRemaining = maxJumps;
            isGrounded = true;
            animator.SetBoolTrue(IS_GROUNDED);
        }
        else
        {
            isGrounded = false; // Velocity Y is in negative
            animator.SetBoolFalse(IS_GROUNDED);
        }
    }


    void OnDrawGizmosSelected() // to visualize ground check box.
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(groundCheck.position, groundCheckSize);
    }

    public void ResetAfterPipeExit()
    {
        rb.gravityScale = baseGravity;
        rb.linearVelocity = Vector2.zero;
        isGrounded = true;
        jumpsRemaining = maxJumps;

        animator.SetBoolTrue(IS_GROUNDED);
        animator.SetFloat(MOVE_Y, -1);
    }

}

