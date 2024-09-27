using TMPro;
using UnityEngine;

public class CrystalManager : MonoBehaviour
{
    public static CrystalManager Instance { get; private set; }

    [SerializeField] 
    private TextMeshProUGUI crystalText;
    
    private int currentCrystal = 0;

    private void Awake()
    {
        Instance = this;
        SetCrystalText();
    }

    private void SetCrystalText()
    {
        crystalText.text = currentCrystal.ToString();
    }

    public void AddCrystal()
    {
        currentCrystal++;
        SetCrystalText();
    }

    public int GetCrystalAmount()
    {
        return currentCrystal;
    }
}
