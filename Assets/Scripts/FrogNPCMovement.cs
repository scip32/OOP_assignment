using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class FrogPattern : MonoBehaviour
{
    private enum State
    {
        MoveLeft1,
        MoveRight,
        MoveLeft2,
        Jump
    }

    [Header("Timings")]
    [Tooltip("Seconds to move left on first pass")]
    public float leftDuration1 = 1.5f;
    [Tooltip("Seconds to move right")]
    public float rightDuration = 3f;
    [Tooltip("Seconds to move left on second pass")]
    public float leftDuration2 = 1.5f;
    [Tooltip("Seconds to remain in jump state before restarting cycle")]
    public float jumpDuration = 0.5f;

    [Header("Movement Settings")]
    public float moveSpeed = 2f;
    public float jumpForce = 5f;

    private Rigidbody2D rb;
    private State currentState;
    private float timer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1f;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void Start()
    {
        EnterState(State.MoveLeft1, leftDuration1);
    }

    void Update()
    {
        timer -= Time.deltaTime;
        switch (currentState)
        {
            case State.MoveLeft1:
            case State.MoveLeft2:
                rb.linearVelocity = new Vector2(-moveSpeed, rb.linearVelocity.y);
                break;

            case State.MoveRight:
                rb.linearVelocity = new Vector2(+moveSpeed, rb.linearVelocity.y);
                break;

            case State.Jump:
                // horizontal velocity zero during jump
                rb.linearVelocity = new Vector2(0f, rb.linearVelocity.y);
                break;
        }

        if (timer <= 0f)
        {
            // advance to next state in the cycle
            switch (currentState)
            {
                case State.MoveLeft1:
                    EnterState(State.MoveRight, rightDuration);
                    break;
                case State.MoveRight:
                    EnterState(State.MoveLeft2, leftDuration2);
                    break;
                case State.MoveLeft2:
                    // trigger jump impulse once
                    rb.linearVelocity = new Vector2(0f, jumpForce);
                    EnterState(State.Jump, jumpDuration);
                    break;
                case State.Jump:
                    EnterState(State.MoveLeft1, leftDuration1);
                    break;
            }
        }
    }

    private void EnterState(State newState, float duration)
    {
        currentState = newState;
        timer = duration;
    }
}
