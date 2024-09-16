using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public Button resortButton;
    public Button beachButton;
    public Button underwaterButton;
    public Button exitButton;
    public TransitionManager transitionManager; // Reference to the TransitionManager

    private void Start()
    {
        // Assign button listeners
        resortButton.onClick.AddListener(() => transitionManager.LoadScene(1));
        beachButton.onClick.AddListener(() => transitionManager.LoadScene(2));
        underwaterButton.onClick.AddListener(() => transitionManager.LoadScene(3));
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnExitButtonClicked()
    {
        // Quit the application
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #endif
    }
}