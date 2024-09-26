using UnityEngine;
using UnityEngine.UI;

public class MainPanel : MonoBehaviour
{
    [SerializeField]
    private Button playButton;
    [SerializeField] 
    private Button settingsButton;
    [SerializeField]
    private Button storeButton;
    [SerializeField] 
    private Button achievementsButton;
    [SerializeField]
    private Button leaderboardButton;
    [SerializeField]
    private Button exitButton;

    [Space(13)] 
    
    [SerializeField] 
    private GameObject levelSelectionPanel;
    [SerializeField] 
    private GameObject settingsPanel;
    [SerializeField] 
    private GameObject storePanel;
    [SerializeField]
    private GameObject achievementsPanel;
    [SerializeField] 
    private GameObject leaderboardPanel;

    private void Start()
    {
        MainButtonClickAction();
    }

    private void MainButtonClickAction()
    {
        if (playButton != null)
        {
            playButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                levelSelectionPanel.SetActive(true);
            });
        }

        if (settingsButton != null)
        {
            settingsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                settingsPanel.SetActive(true);
            });
        }

        if (storeButton != null)
        {
            storeButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                storePanel.SetActive(true);
            });
        }

        if (achievementsButton != null)
        {
            achievementsButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                achievementsPanel.SetActive(true);
            });
        }

        if (leaderboardButton != null)
        {
            leaderboardButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                leaderboardPanel.SetActive(true);
            });
        }

        if (exitButton != null)
        {
            exitButton.onClick.AddListener(() =>
            {
                Application.Quit();
            });
        }
    }
}
