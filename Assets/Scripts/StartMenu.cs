using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Button))]
public class NextSceneButtonNoTag : MonoBehaviour
{
    private Button _button;

    void Awake()
    {
        // automatically get the Button component
        _button = GetComponent<Button>();
        if (_button == null)
        {
            Debug.LogError($"[{nameof(NextSceneButtonNoTag)}] 未找到 Button 组件！");
            return;
        }
        // add listener to the button click event
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int nextIndex = currentIndex + 1;

        if (nextIndex >= SceneManager.sceneCountInBuildSettings)
        {
            Debug.LogWarning($"[{nameof(NextSceneButtonNoTag)}] 下一个场景索引 {nextIndex} 超出范围，共有 {SceneManager.sceneCountInBuildSettings} 个场景。");
            return;
        }

        SceneManager.LoadScene(nextIndex);
    }
}
