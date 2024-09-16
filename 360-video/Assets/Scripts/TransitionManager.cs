using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class TransitionManager : MonoBehaviour
{
    public Image fadeScreen; // The full-screen fade image
    public Image lockedImage; // The locked image in the center
    public float fadeDuration = 1.0f;

    private void Start()
    {
        fadeScreen.color = new Color(0, 0, 0, 1); // Start fully opaque
        lockedImage.gameObject.SetActive(false); // Hide the locked image
        StartCoroutine(FadeOut());
    }

    public void LoadScene(int sceneIndex)
    {
        StartCoroutine(TransitionToScene(sceneIndex));
    }

    private IEnumerator TransitionToScene(int sceneIndex)
    {
        lockedImage.gameObject.SetActive(true); // Show the locked image
        yield return FadeIn(); // Fade in
        SceneManager.LoadScene(sceneIndex); // Load new scene
        yield return FadeOut(); // Fade out
        lockedImage.gameObject.SetActive(false); // Hide the locked image
    }

    private IEnumerator FadeIn()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = elapsedTime / fadeDuration;
            fadeScreen.color = new Color(0, 0, 0, alpha); // Change alpha
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeScreen.color = new Color(0, 0, 0, 1);
    }

    private IEnumerator FadeOut()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = 1 - (elapsedTime / fadeDuration);
            fadeScreen.color = new Color(0, 0, 0, alpha); // Change alpha
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        fadeScreen.color = new Color(0, 0, 0, 0);
    }
}