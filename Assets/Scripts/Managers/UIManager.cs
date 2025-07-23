using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _startUI;
    [SerializeField] GameObject _gameUI;
    [SerializeField] GameObject _countUI;
    [SerializeField] GameObject _scoreUI;

    public void StartGame()
    {
        _gameUI.SetActive(true);
        _countUI.SetActive(true);
        _scoreUI.SetActive(true);
        _startUI.SetActive(false);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
