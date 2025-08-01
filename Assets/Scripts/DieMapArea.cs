using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// <summary>
/// restart and wait for 1 second after 10 seconds of no collision.
/// prevents the player from getting stuck in the map area.
/// </summary>
public class DieMapArea : MonoBehaviour
{
    // record the last time a collision occurred
    private float lastCollisionTime;

    // record if we are currently restarting
    private bool isRestarting = false;

    void Start()
    {
        // initialize the last collision time to the current time
        lastCollisionTime = Time.time;
    }

    void Update()
    {
        // if we are already restarting, do nothing
        if (isRestarting)
            return;

        // if 10 seconds have passed since the last collision,
        if (Time.time - lastCollisionTime >= 10f)
        {
            isRestarting = true;
            StartCoroutine(RestartAfterDelay(1f));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // if the player collides with something, reset the last collision time
        lastCollisionTime = Time.time;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // reset the last collision time when entering a trigger collider
        lastCollisionTime = Time.time;
    }

    /// <summary>
    /// after a delay, this coroutine will pause the game,
    /// reset the time scale, and reload the current scene.
    /// </summary>
    private IEnumerator RestartAfterDelay(float delaySeconds)
    {

        // stop the game time
        Time.timeScale = 0f;

        // wait for the specified delay
        yield return new WaitForSecondsRealtime(delaySeconds);

        // reset the time scale to normal
        Time.timeScale = 1f;

        // reload the current scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
