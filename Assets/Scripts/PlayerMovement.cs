using UnityEngine;

// Define states
public enum PlayerState
{
    Idle = 0,
    Run = 1,
    Jump = 2,
    Fall = 3
}

[RequireComponent(typeof(Rigidbody2D), typeof(Animator), typeof(SpriteRenderer))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float moveSpeed = 5f;
    public float jumpForce = 10f;

    // cached components
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer sprite;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Read inputs & apply movement
        float xInput = Input.GetAxisRaw("Horizontal");      // -1, 0 or +1
        bool jumpPress = Input.GetButtonDown("Jump");       // Space/W/↑ by default

        // horizontal velocity
        float vx = xInput * moveSpeed;
        rb.linearVelocity = new Vector2(vx, rb.linearVelocity.y);

        // flip sprite
        if (xInput < 0) sprite.flipX = true;
        else if (xInput > 0) sprite.flipX = false;

        // jump
        bool grounded = IsGrounded();
        if (grounded && jumpPress)
            rb.linearVelocity = new Vector2(vx, jumpForce);

        // Decide current state
        PlayerState state;
        float vy = rb.linearVelocity.y;

        if (!grounded)
        {
            // in mid‑air
            state = (vy > 0.1f) ? PlayerState.Jump : PlayerState.Fall;
        }
        else if (Mathf.Abs(xInput) > 0.1f)
        {
            state = PlayerState.Run;
        }
        else
        {
            state = PlayerState.Idle;
        }

        // Push into Animator
        animator.SetInteger("state", (int)state);
    }

    private bool IsGrounded()
    {
        // simple check—replace with your own Ground‐Layer test if needed
        return Mathf.Abs(rb.linearVelocity.y) < 0.001f;
    }
}