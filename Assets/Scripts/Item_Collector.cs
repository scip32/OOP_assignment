using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemCollector : MonoBehaviour
{
    // This script handles the collection of items (apples) in a 2D game.
    [Header("Tag & UI")]
    [Tooltip("Make sure all apples are tagged exactly “Apple”")]
    [SerializeField] private string collectibleTag = "Apple";

    [Tooltip("Drag your UI Text here (under Canvas)")]
    [SerializeField] private Text counterText;

    [SerializeField] private int targetCount = 13;

    private int appleCount = 0;

    void Start()
    {
        if (counterText == null)
            Debug.LogError("ItemCollector ▶ counterText not assigned! Drag your UI Text into this field.");

        UpdateUI();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(collectibleTag))
            return;

        appleCount++;
        Destroy(other.gameObject);
        UpdateUI();

        // apple count check
        if (appleCount >= targetCount)
        {
            LoadNextLevel();
        }
    }

    private void UpdateUI()
    {
        if (counterText != null)
            counterText.text = $"Apples: {appleCount}";
    }

    private void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextIndex);
        }
        else
        {
            Debug.Log("All levels complete.");
        }
    }
}
