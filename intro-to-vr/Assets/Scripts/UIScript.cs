using UnityEngine;
using UnityEngine.UI;

public class UIScript : MonoBehaviour
{
    public Button playButton;
    public Button exitButton;

    private void Start()
    {
        playButton.onClick.AddListener(OnPlayButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    private void OnPlayButtonClicked()
    {

    }



    private void OnExitButtonClicked()
    {
        // Quit the application
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}