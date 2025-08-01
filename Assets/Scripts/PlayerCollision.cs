using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollision : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Player collided with: " + collision.collider.name);

        if (collision.collider.CompareTag("Trap"))
        {
            Debug.Log("Touched Enemy! Player DIES.");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Restart scene
        }
    }
}
