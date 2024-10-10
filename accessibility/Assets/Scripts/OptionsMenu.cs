using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;

public class OptionsMenu : MonoBehaviour
{
    public Slider gazeDurationSlider;
    public Toggle locomotionToggle;
    public Dropdown rotationDropdown;
    private float gazeDuration;
    private AudioSource audioSource;
    public AudioClip gazeEnterSound;
    public AudioClip gazeSelectSound;
    public AudioClip gazeExitSound;

    private void Start()
    {
        // Load saved preferences or set default values
        gazeDurationSlider.value = PlayerPrefs.GetFloat("GazeDuration", 2.0f);
        locomotionToggle.isOn = PlayerPrefs.GetInt("LocomotionType", 1) == 1;
        rotationDropdown.value = PlayerPrefs.GetInt("RotationType", 0);

        // Add listeners to UI elements
        gazeDurationSlider.onValueChanged.AddListener(OnGazeDurationChanged);
        locomotionToggle.onValueChanged.AddListener(OnLocomotionToggleChanged);
        rotationDropdown.onValueChanged.AddListener(OnRotationTypeChanged);

        // Initialize gaze duration from PlayerPrefs
        gazeDuration = PlayerPrefs.GetFloat("GazeDuration", 2.0f);

        // Initialize audio source
        audioSource = gameObject.AddComponent<AudioSource>();
    }

    private void OnGazeDurationChanged(float value)
    {
        PlayerPrefs.SetFloat("GazeDuration", value);
        PlayerPrefs.Save();
        gazeDuration = value; 
    }

    private void OnLocomotionToggleChanged(bool isTeleport)
    {
        PlayerPrefs.SetInt("LocomotionType", isTeleport ? 1 : 0);
        PlayerPrefs.Save();
    }

    private void OnRotationTypeChanged(int index)
    {
        PlayerPrefs.SetInt("RotationType", index);
        PlayerPrefs.Save();
    }

    private void PlayAudio(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }
}