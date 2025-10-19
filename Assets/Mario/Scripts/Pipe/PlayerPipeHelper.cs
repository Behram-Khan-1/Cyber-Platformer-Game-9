// using UnityEngine;

// public class PlayerPipeHelper : MonoBehaviour
// {
//     Rigidbody2D rb;
//     public Transform groundCheck;
//     public Vector3 groundCheckSize;
//     public LayerMask groundLayer;
//     public CharacterMovement player;
//     public CharacterAnimatorManager animator;

//     void Start()
//     {
//         rb = GetComponent<Rigidbody2D>();
//         player = GetComponent<CharacterMovement>();
//         animator = GetComponent<CharacterAnimatorManager>();
        
//     }

//     public void ResetAfterPipeExit()
//     {
//         rb.gravityScale = player.baseGravity;
//         rb.linearVelocity = Vector2.zero;
//         isGrounded = true;
//         jumpsRemaining = maxJumps;

//         animator.SetBoolTrue(IS_GROUNDED);
//         animator.SetFloat(MOVE_Y, 0);
//     }
// }
