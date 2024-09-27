using System.Collections.Generic;
using Dan.Main;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LeaderboardPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField]
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField]
    private List<TextMeshProUGUI> nameText;
    [SerializeField] 
    private List<TextMeshProUGUI> scoreText;

    private string publicLeaderboardKey = "82ae937c1c7825497578b476d889d7342c0f6a68112829af853420d8ab1bd2db";

    private void Awake()
    {
        LeaderboardButtonClickAction();
    }

    private void OnEnable()
    {
        GetLeaderboard();
    }

    private void LeaderboardButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }
    }

    private void GetLeaderboard()
    {
        LeaderboardCreator.GetLeaderboard(publicLeaderboardKey, ((msg) =>
        {
            int loopLenght = (msg.Length < nameText.Count) ? msg.Length : nameText.Count;

            for (int i = 0; i < loopLenght; i++)
            {
                nameText[i].text = msg[i].Username;
                scoreText[i].text = msg[i].Score.ToString();
            }
        }));
    }
}
