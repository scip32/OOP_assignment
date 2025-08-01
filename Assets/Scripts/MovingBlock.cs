using UnityEngine;
using System.Collections;

public class MovingBlock : MonoBehaviour
{
    public float moveDistance = 5f;       // Distance to move left and right
    public float moveSpeed = 2f;          // Movement speed
    public float pauseTime = 0.5f;        // Time to stop at each edge

    private Vector3 leftEdge;
    private Vector3 rightEdge;
    private bool movingRight = true;
    private bool isPaused = false;

    void Start()
    {
        leftEdge = transform.position - Vector3.right * moveDistance;
        rightEdge = transform.position + Vector3.right * moveDistance;
        StartCoroutine(MoveBlock());
    }

    IEnumerator MoveBlock()
    {
        while (true)
        {
            if (!isPaused)
            {
                Vector3 target = movingRight ? rightEdge : leftEdge;
                transform.position = Vector3.MoveTowards(transform.position, target, moveSpeed * Time.deltaTime);

                if (Vector3.Distance(transform.position, target) < 0.01f)
                {
                    isPaused = true;
                    yield return new WaitForSeconds(pauseTime);
                    movingRight = !movingRight;
                    isPaused = false;
                }
            }

            yield return null;
        }
    }
}
