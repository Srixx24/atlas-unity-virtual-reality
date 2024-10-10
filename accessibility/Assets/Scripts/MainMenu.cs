using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class VRMenuButton : MonoBehaviour
{
    public Button startButton;
    public Button settingsButton;
    public Button exitButton;
    public AudioClip gazeEnterSound;
    public AudioClip gazeSelectSound;
    public AudioClip gazeExitSound;

    private AudioSource audioSource;
    private XRBaseInteractable interactable;

    // Reference to the camera for setting menu
    public Transform player;

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        interactable = GetComponent<XRBaseInteractable>();

        // Set up XR interaction listeners
        if (interactable != null)
        {
            interactable.onHoverEntered.AddListener(OnGazeEnter);
            interactable.onHoverExited.AddListener(OnGazeExit);
            interactable.onSelectEntered.AddListener(OnGazeSelect);
        }
        else
        {
            Debug.LogError("XRBaseInteractable component missing on this GameObject.");
        }

        // Set up UI button listeners
        startButton.onClick.AddListener(OnStartButtonClick);
        settingsButton.onClick.AddListener(OnSettingsButtonClick);
        exitButton.onClick.AddListener(OnExitButtonClicked);
    }

    public void OnGazeEnter(XRBaseInteractor interactor)
    {
        audioSource.PlayOneShot(gazeEnterSound);
    }

    public void OnGazeExit(XRBaseInteractor interactor)
    {
        audioSource.PlayOneShot(gazeExitSound);
    }

    public void OnGazeSelect(XRBaseInteractor interactor)
    {
        audioSource.PlayOneShot(gazeSelectSound);
    }

    private void OnStartButtonClick()
    {
        SceneManager.LoadScene(2);
    }

    private void OnSettingsButtonClick()
    {
        SceneManager.LoadScene(1);
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