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

    [Space(13)]
    
    [SerializeField]
    private int currentLevelIndex;
    private int maxLevelIndex = 7;

    private string publicLeaderboardKey = "82ae937c1c7825497578b476d889d7342c0f6a68112829af853420d8ab1bd2db";

    private void Awake()
    {
        Instance = this;
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
    }

    public void LoseGame()
    {
        losePanel.SetActive(true);
        UpdateLeaderboard();
        CrystalData.Instance.PlusCrystal(CrystalManager.Instance.GetCrystalAmount());
    }

    public void WinGame()
    {
        winPanel.SetActive(true);
        UpdateLeaderboard();
        CrystalData.Instance.PlusCrystal(CrystalManager.Instance.GetCrystalAmount());

        if (currentLevelIndex < maxLevelIndex)
        {
            LevelData.Instance.CompleteLevel(currentLevelIndex + 1);
        }

        if (currentLevelIndex == maxLevelIndex)
        {
            LevelData.Instance.CompleteLevel(currentLevelIndex);
        }
    }

    private void UpdateLeaderboard()
    {
        int score = PlayerPrefs.GetInt("LeaderboardScore", 0) + CrystalManager.Instance.GetCrystalAmount();
        LeaderboardCreator.UploadNewEntry(publicLeaderboardKey, PlayerPrefs.GetString("Username"), score);
    }
}
