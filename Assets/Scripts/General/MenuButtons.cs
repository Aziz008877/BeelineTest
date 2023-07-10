using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuButtons : MonoBehaviour
{
    [SerializeField] private Button _closeGameButton;
    [SerializeField] private Button _restartLevelButton;

    private void Start()
    {
        _closeGameButton.onClick.AddListener(delegate
        {
            Application.Quit();
        });
        
        _restartLevelButton.onClick.AddListener(delegate
        {
            SceneManager.LoadScene("Game");
        });
    }
}
