using UnityEngine;
using UnityEngine.UI;

public class LosePanel : MonoBehaviour
{
    [SerializeField] 
    private Button restartButton;
    [SerializeField] 
    private Button menuButton;

    private void Awake()
    {
        LoseButtonClickAction();
    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
    }

    private void LoseButtonClickAction()
    {
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
