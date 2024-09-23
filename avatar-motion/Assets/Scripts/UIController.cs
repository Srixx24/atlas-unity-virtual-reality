using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public MirrorCam mirrorCam; // Reference to the MirrorCam script
    public Button recordButton;
    public Button stopButton;
    public Button playButton;
    public Button nextButton;
    public Button exitButton;
    public Image recordingIndicator; // Reference to the UI Image for recording feedback

    private void Start()
    {
        // Assign button listeners
        recordButton.onClick.AddListener(OnRecordButtonClicked);
        stopButton.onClick.AddListener(OnStopButtonClicked);
        playButton.onClick.AddListener(OnPlayButtonClicked);
        nextButton.onClick.AddListener(OnNextButtonClicked);
        exitButton.onClick.AddListener(OnExitButtonClicked);

        recordingIndicator.gameObject.SetActive(false);
    }

    private void OnRecordButtonClicked()
    {
        mirrorCam.StartRecording();
        recordingIndicator.gameObject.SetActive(true); // Show the recording indicator
    }

    private void OnStopButtonClicked()
    {
        mirrorCam.StopRecording();
        recordingIndicator.gameObject.SetActive(false); // Hide the recording indicator
    }

    private void OnPlayButtonClicked()
    {
        mirrorCam.PlayLastClip();
    }

    private void OnNextButtonClicked()
    {
        mirrorCam.PlayNextClip();
    }

    private void OnExitButtonClicked()
    {
        // Quit the application
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Debug.Log("Exiting application.");
    }
}