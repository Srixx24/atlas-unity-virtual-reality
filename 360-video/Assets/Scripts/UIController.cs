using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class UIController : MonoBehaviour
{
    public Button playbackSpeedButton;
    public Button playButton;
    public Button pauseButton;
    public Button skipButton;
    public Button mainMenuButton;
    public Button exitButton;

    public VideoPlayer videoPlayer;
    public TransitionManager transitionManager;

    private float[] playbackSpeeds = { 1f, 2f, 3f };
    private int currentSpeedIndex = 0;

    private void Start()
    {
        // Assign button listeners
        playbackSpeedButton.onClick.AddListener(OnPlaybackSpeedButtonClicked);
        playButton.onClick.AddListener(OnPlayButtonClicked);
        pauseButton.onClick.AddListener(OnPauseButtonClicked);
        skipButton.onClick.AddListener(OnSkipButtonClicked);
        mainMenuButton.onClick.AddListener(OnMainMenuButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);

        // Initialize buttons
        UpdatePlayPauseButtons();
    }

    private void OnPlaybackSpeedButtonClicked()
    {
        // Change video playback speed
        currentSpeedIndex = (currentSpeedIndex + 1) % playbackSpeeds.Length;
        videoPlayer.playbackSpeed = playbackSpeeds[currentSpeedIndex];
        playbackSpeedButton.GetComponentInChildren<Text>().text = $"{playbackSpeeds[currentSpeedIndex]}x";
    }

    private void OnPlayButtonClicked()
    {
        videoPlayer.Play();
        UpdatePlayPauseButtons();
    }

    private void OnPauseButtonClicked()
    {
        videoPlayer.Pause();
        UpdatePlayPauseButtons();
    }

    private void OnSkipButtonClicked()
    {
        if (transitionManager == null)
        {
            return;
        }

        // Load the next scene with TransitionManager
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            transitionManager.LoadScene(nextSceneIndex);
        }
        else
        {
            // Loop back to first video scene
            transitionManager.LoadScene(1);
        }
    }

    private void OnMainMenuButtonClicked()
    {
        if (transitionManager == null)
        {
            return;
        }

        // Load the main menu scene with TransitionManager
        transitionManager.LoadScene(0);
    }

    private void OnExitButtonClicked()
    {
        // Quit the application
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // Stop play mode in the editor
        #endif
    }

    private void UpdatePlayPauseButtons()
    {
        playButton.gameObject.SetActive(!videoPlayer.isPlaying);
        pauseButton.gameObject.SetActive(videoPlayer.isPlaying);
    }
}