using UnityEngine;

public class CircularMover : MonoBehaviour
{
    [Header("Orbit Settings")]
    [Tooltip("Transform to orbit around. If null, uses world origin (0,0,0).")]
    [SerializeField] private Transform center;
    [Tooltip("Radius of the circular path.")]
    [SerializeField] private float radius = 2f;
    [Tooltip("Angular speed in degrees per second. Positive → clockwise.")]
    [SerializeField] private float angularSpeed = 90f;

    // current angle in degrees
    private float currentAngle = 0f;

    void Start()
    {
        // If no center assigned, default to world origin
        if (center == null)
        {
            GameObject go = new GameObject("OrbitCenter");
            go.transform.position = Vector3.zero;
            center = go.transform;
        }

        // Initialize angle based on starting position (optional)
        Vector3 offset = transform.position - center.position;
        if (offset.sqrMagnitude > 0.0001f)
            currentAngle = Mathf.Atan2(offset.y, offset.x) * Mathf.Rad2Deg;
    }

    void Update()
    {
        // Move angle forward clockwise
        currentAngle -= angularSpeed * Time.deltaTime;

        // Convert to radians for trig
        float rad = currentAngle * Mathf.Deg2Rad;

        // Compute new position
        Vector3 newPos = new Vector3(
            Mathf.Cos(rad) * radius,
            Mathf.Sin(rad) * radius,
            0f
        );

        transform.position = center.position + newPos;
    }
}
