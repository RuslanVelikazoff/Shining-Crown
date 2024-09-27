using Dan.Main;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [SerializeField]
    private GameObject pausePanel;
    [SerializeField] 
    private GameObject losePanel;
    [SerializeField]
    private GameObject winPanel;

    private string publicLeaderboardKey = "82ae937c1c7825497578b476d889d7342c0f6a68112829af853420d8ab1bd2db";

    private void Awake()
    {
        Instance = this;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void LoseGame()
    {
        Time.timeScale = 0f;
        losePanel.SetActive(true);
        UpdateLeaderboard();
    }

    public void WinGame()
    {
        Time.timeScale = 0f;
        winPanel.SetActive(true);
        UpdateLeaderboard();
    }

    private void UpdateLeaderboard()
    {
        int score = PlayerPrefs.GetInt("LeaderboardScore", 0) + CrystalManager.Instance.GetCrystalAmount();
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, PlayerPrefs.GetString("Username"), score);
    }
}
