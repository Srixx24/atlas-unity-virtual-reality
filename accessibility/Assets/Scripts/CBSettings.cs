using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class CBSettings : MonoBehaviour
{
    [SerializeField] public Button highContrastButton;
    [SerializeField] public Button protDeuterButton;
    [SerializeField] public Button tritanopiaButton;
    [SerializeField] public Button resetButton;

    // Default Colors
    private Color defaultBackground = new Color32(27, 27, 27, 255);
    private Color defaultText = new Color32(255, 255, 255, 255);
    private Color defaultButton = new Color32(195, 111, 42, 255);
    private Color defaultHighlightedButton = new Color32(179, 90, 16, 255);
    private Color defaultCallToActionButton = new Color32(243, 164, 100, 255);
    private Color defaultOtherUIElements = new Color32(195, 111, 42, 255);

    private List<Text> allTexts = new List<Text>();
    private List<Button> allButtons = new List<Button>();
    private List<Image> allImages = new List<Image>();

    private void Start()
    {
        GatherUIComponents();

        highContrastButton.onClick.AddListener(ApplyHighContrastSettings);
        protDeuterButton.onClick.AddListener(ApplyProtDeuterButtonSettings);
        tritanopiaButton.onClick.AddListener(ApplyTritanopiaSettings);
        resetButton.onClick.AddListener(ResetToDefault);
    }

    private void GatherUIComponents()
    {
        allTexts.AddRange(FindObjectsOfType<Text>());
        allButtons.AddRange(FindObjectsOfType<Button>());
        allImages.AddRange(FindObjectsOfType<Image>());
    }

    private void ApplyHighContrastSettings()
    {
        SetMenuBackground(Color.black);
        SetTextColors(Color.white, new Color(0.8f, 0.8f, 0.8f));
        SetButtonColors(new Color(0.333f, 0.333f, 0.333f), Color.blue);
        SetCallToActionButton(Color.yellow, Color.black);
        SetOtherUIElements(new Color(0.666f, 0.666f, 0.666f), Color.white);
    }

    private void ApplyProtDeuterButtonSettings()
    {
        SetMenuBackground(new Color(0, 0, 0.2f));
        SetTextColors(new Color(1, 1, 0), new Color(0.4f, 0.6f, 1));
        SetButtonColors(new Color(0.5f, 0.5f, 0.5f), new Color(1, 0.647f, 0));
        SetCallToActionButton(new Color(1, 0, 1), Color.white);
        SetOtherUIElements(new Color(0.752f, 0.752f, 0.752f), new Color(1, 1, 0));
    }

    private void ApplyTritanopiaSettings()
    {
        SetMenuBackground(new Color(0.2f, 0.2f, 0.2f));
        SetTextColors(Color.white, new Color(0.8f, 0.8f, 0.8f));
        SetButtonColors(new Color(0.5f, 0.5f, 0), new Color(0.529f, 0.808f, 0.980f));
        SetCallToActionButton(Color.red, Color.white);
        SetOtherUIElements(new Color(0.96f, 0.96f, 0.86f), new Color(0.5f, 0.5f, 0));
    }

    private void ResetToDefault()
    {
        SetMenuBackground(defaultBackground);
        SetTextColors(defaultText, defaultText);
        SetButtonColors(defaultButton, defaultHighlightedButton);
        SetCallToActionButton(defaultCallToActionButton, Color.black);
        SetOtherUIElements(defaultOtherUIElements, Color.white);
    }

    private void SetMenuBackground(Color color)
    {
        Camera.main.backgroundColor = color;
    }

    private void SetTextColors(Color titleColor, Color subtitleColor)
    {
        foreach (var text in allTexts)
        {
            if (text.CompareTag("Title"))
                text.color = titleColor;
            else
                text.color = subtitleColor;
        }
    }

    private void SetButtonColors(Color standardColor, Color highlightedColor)
    {
        foreach (var button in allButtons)
        {
            var buttonImage = button.GetComponent<Image>();
            if (buttonImage != null)
            {
                buttonImage.color = standardColor;
            }
        }
    }

    private void SetCallToActionButton(Color backgroundColor, Color textColor)
    {
        foreach (var button in allButtons)
        {
            if (button.name == "CallToActionButton")
            {
                var buttonImage = button.GetComponent<Image>();
                if (buttonImage != null)
                {
                    buttonImage.color = backgroundColor;
                }
                var buttonText = button.GetComponentInChildren<Text>();
                if (buttonText != null)
                {
                    buttonText.color = textColor;
                }
            }
        }
    }

    private void SetOtherUIElements(Color backgroundColor, Color highlightColor)
    {
        foreach (var image in allImages)
        {
            image.color = backgroundColor;
        }
    }
}