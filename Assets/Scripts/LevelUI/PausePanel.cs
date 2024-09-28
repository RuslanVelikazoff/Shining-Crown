using UnityEngine;
using UnityEngine.UI;

public class PausePanel : MonoBehaviour
{
    [SerializeField] 
    private Button resumeButton;
    [SerializeField] 
    private Button restartButton;
    [SerializeField] 
    private Button menuButton;

    private void Awake()
    {
        PauseButtonClickAction();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private void PauseButtonClickAction()
    {
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(() =>
            {
                Time.timeScale = 1f;
                this.gameObject.SetActive(false);
            });
        }

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(() =>
            {
                Loader.Load(Loader.targetScene);
            });
        }

        if (menuButton != null)
        {
            menuButton.onClick.AddListener(() =>
            {
                Loader.Load("Menu");
            });
        }
    }
}
