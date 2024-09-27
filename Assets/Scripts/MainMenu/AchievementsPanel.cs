using UnityEngine;
using UnityEngine.UI;

public class AchievementsPanel : MonoBehaviour
{
    [SerializeField] 
    private Button backButton;
    [SerializeField] 
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField] 
    private GameObject[] completeAchievement;

    private void OnEnable()
    {
        for (int i = 0; i < completeAchievement.Length; i++)
        {
            if (AchievementsData.Instance.IsAchievementComplete(i))
            {
                completeAchievement[i].SetActive(true);
            }
            else
            {
                completeAchievement[i].SetActive(false);
            }
        }
    }

    private void Awake()
    {
        AchievementsButtonClickAction();
    }

    private void AchievementsButtonClickAction()
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
}
