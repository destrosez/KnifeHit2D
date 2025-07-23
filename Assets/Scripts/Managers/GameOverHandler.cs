using UnityEngine;

public class GameOverHandler : MonoBehaviour
{
    public static GameOverHandler Instance;
    
    [SerializeField] private GameObject _gamePanel;
    [SerializeField] private GameObject _losePanel;
    [SerializeField] private GameObject _countKnifeUI;
    [SerializeField] private GameObject _countAppleUI;


    private void Awake()
    {
        if (Instance == null) Instance = this;
        else if (Instance == this) Destroy(gameObject);
    }

    public void TriggerGameOver()
    {
        _losePanel.SetActive(true);
        _gamePanel.SetActive(false);
        _countKnifeUI.SetActive(false);
        _countAppleUI.SetActive(false);
    }
}
