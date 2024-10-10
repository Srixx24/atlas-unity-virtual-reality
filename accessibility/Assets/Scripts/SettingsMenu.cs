using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public Button backButton;
    public Slider textSizeSlider;
    public Button resetTextButton;
    public Dropdown windowSizeDropdown;

    private const string TextSizeKey = "TextSize"; // Key for PlayerPrefs
    private const float DefaultTextSize = 14f;

    void Start()
    {
        // Load the saved text size or set to default
        float savedTextSize = PlayerPrefs.GetFloat(TextSizeKey, DefaultTextSize);
        textSizeSlider.value = savedTextSize;

        // Button listeners
        backButton.onClick.AddListener(GoBackToMainMenu);
        textSizeSlider.onValueChanged.AddListener(UpdateTextSize);
        resetTextButton.onClick.AddListener(ResetTextSize);
        
        // Setup dropdown options
        windowSizeDropdown.ClearOptions();
        windowSizeDropdown.AddOptions(new List<string> { "Default", "Wide", "Tall" });
        windowSizeDropdown.onValueChanged.AddListener(UpdateWindowSize);
    }

    private void GoBackToMainMenu()
    {
        SceneManager.LoadScene(0);

        // Save current settings before leaving the scene
        PlayerPrefs.SetFloat(TextSizeKey, textSizeSlider.value);
    }

    private void UpdateTextSize(float newSize)
    {
        ApplyTextSize(newSize);
    }

    private void ResetTextSize()
    {
        textSizeSlider.value = DefaultTextSize; // Reset to default
        ApplyTextSize(DefaultTextSize);          // Apply default size
    }

    private void UpdateWindowSize(int index)
    {
        switch (index)
        {
            case 0: // Default
                SetWindowSize(Vector2.one);
                break;
            case 1: // Wide
                SetWindowSize(new Vector2(1920, 1080));
                break;
            case 2: // Tall
                SetWindowSize(new Vector2(1080, 1920));
                break;
        }
    }

    private void ApplyTextSize(float size)
    {
        // Find all Text components in the scene and set their font size
        foreach (Text textElement in FindObjectsOfType<Text>())
        {
            textElement.fontSize = Mathf.RoundToInt(size);
        }

        //For Txt mesh pro texts
        foreach (TMP_Text tmpTextElement in FindObjectsOfType<TMP_Text>())
        {
            tmpTextElement.fontSize = size;
        }
    }

    private void SetWindowSize(Vector2 size)
    {
        // Adjust the Canvas size based on the selected window size
        RectTransform canvasRectTransform = GetComponent<RectTransform>();
        if (canvasRectTransform != null)
        {
            canvasRectTransform.sizeDelta = size;
            canvasRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
            canvasRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
            canvasRectTransform.pivot = new Vector2(0.5f, 0.5f);
        }
    }
}