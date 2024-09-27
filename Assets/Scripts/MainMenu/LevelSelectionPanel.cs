using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionPanel : MonoBehaviour
{
    [SerializeField] private Button backButton;
    [SerializeField] private GameObject mainPanel;

    [SerializeField] private Button[] levelButton;
    [SerializeField] private GameObject[] lockGameObject;
    [SerializeField] private Slider progressSlider;

    private int maxProgress = 7;
    private int currentProgress;

    private void OnEnable()
    {
        LevelSelectionButtonClickAction();
        SetButtonSprite();
        SetProgressSlider();
    }

    private void LevelSelectionButtonClickAction()
    {
        if (levelButton[0] != null)
        {
            levelButton[0].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsLevelUnlock(0))
                {
                    Loader.Load("Level1");
                }
            });
        }
        
        if (levelButton[1] != null)
        {
            levelButton[1].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsLevelUnlock(1))
                {
                    Loader.Load("Level2");
                }
            });
        }
        
        if (levelButton[2] != null)
        {
            levelButton[2].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsLevelUnlock(2))
                {
                    Loader.Load("Level3");
                }
            });
        }
        
        if (levelButton[3] != null)
        {
            levelButton[3].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsLevelUnlock(3))
                {
                    Loader.Load("Level4");
                }
            });
        }
        
        if (levelButton[4] != null)
        {
            levelButton[4].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsLevelUnlock(4))
                {
                    Loader.Load("Level5");
                }
            });
        }
        
        if (levelButton[5] != null)
        {
            levelButton[5].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsLevelUnlock(5))
                {
                    Loader.Load("Level6");
                }
            });
        }
        
        if (levelButton[6] != null)
        {
            levelButton[6].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsLevelUnlock(6))
                {
                    Loader.Load("Level7");
                }
            });
        }
        
        if (levelButton[7] != null)
        {
            levelButton[7].onClick.AddListener(() =>
            {
                if (LevelData.Instance.IsLevelUnlock(7))
                {
                    Loader.Load("Level7");
                }
            });
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
            });
        }
    }

    private void SetButtonSprite()
    {
        for (int i = 0; i < lockGameObject.Length; i++)
        {
            if (LevelData.Instance.IsLevelUnlock(i))
            {
                lockGameObject[i].SetActive(false);
            }
            else
            {
                lockGameObject[i].SetActive(true);
            }
        }
    }

    private void SetProgressSlider()
    {
        progressSlider.maxValue = maxProgress;

        for (int i = 0; i < maxProgress; i++)
        {
            if (LevelData.Instance.IsLevelCompleted(i))
            {
                currentProgress = i;
            }
        }

        progressSlider.value = currentProgress;
    }
}
