using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinPanel : MonoBehaviour
{
    [SerializeField]
    private Button menuButton;
    [SerializeField]
    private Button restartButton;

    [SerializeField] 
    private TextMeshProUGUI crystalText;

    private void OnEnable()
    {
        SetCrystalText();
        WinButtonClickAction();
    }

    private void SetCrystalText()
    {
        crystalText.text = CrystalManager.Instance.GetCrystalAmount().ToString();
    }

    private void WinButtonClickAction()
    {
        if (menuButton != null)
        {
            menuButton.onClick.AddListener(() =>
            {
                Loader.Load("Menu");
            });
        }

        if (restartButton != null)
        {
            restartButton.onClick.AddListener(() =>
            {
                Loader.Load(Loader.targetScene);
            });
        }
    }
}
