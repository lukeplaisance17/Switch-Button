using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TryAgainModalBehaviour : MonoBehaviour
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;

    private void OnEnable()
    {
        _yesButton.onClick.AddListener(OnYesButtonClicked);
        _noButton.onClick.AddListener(OnNoButtonClicked);
    }

    private void OnDisable()
    {
        _yesButton.onClick.RemoveListener(OnYesButtonClicked);
        _noButton.onClick.RemoveListener(OnNoButtonClicked);
    }

    private void OnYesButtonClicked()
    {
        SceneManager.LoadScene(0);
    }

    private void OnNoButtonClicked()
    {
        Application.Quit();
    }
}
