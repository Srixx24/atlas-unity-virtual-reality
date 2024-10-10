using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.UI;

public class ReturnMenu : MonoBehaviour
{
    public Button returnButton;

    // Start is called before the first frame update
    void Start()
    {
        returnButton.onClick.AddListener(OnReturnButtonClicked);
    }

    private void OnReturnButtonClicked()
    {
        SceneManager.LoadScene(0);
    }
}
