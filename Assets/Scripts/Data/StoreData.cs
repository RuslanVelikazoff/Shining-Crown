using UnityEngine;

public class StoreData : MonoBehaviour
{
    private const string SaveKey = "MainSaveStore";

    private bool[] _purchasedKnight;
    private bool[] _selectedKnight;

    private bool _purchasedShield;
    private bool _purchasedSphere;

    public static StoreData Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        Load();

        PlayerPrefs.GetInt("SelectedKnight", 0);
        PlayerPrefs.GetInt("PurchasedShield", 0);
        PlayerPrefs.GetInt("PurchasedSphere", 0);
        
        for (int i = 0; i < _selectedKnight.Length; i++)
        {
            if (IsSelectedKnight(i))
            {
                PlayerPrefs.SetInt("SelectedKnight", i);
            }
            else
            {
                continue;
            }
        }

        if (IsPurchasedShield())
        {
            PlayerPrefs.SetInt("PurchasedShield", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PurchasedShield", 0);
        }

        if (IsPurchasedSphere())
        {
            PlayerPrefs.SetInt("PurchasedSphere", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PurchasedSphere", 0);
        }
    }

    private void OnApplicationQuit()
    {
        Save();
    }

    private void OnApplicationPause(bool pauseStatus)
    {
        if (pauseStatus)
        {
            Save();
        }
    }

    private void OnDisable()
    {
        Save();
    }

    private void Load()
    {
        var data = SaveManager.Load<GameData>(SaveKey);

        _purchasedKnight = data.purchasedKnight;
        _selectedKnight = data.selectedKnight;
        _purchasedShield = data.purchasedShield;
        _purchasedSphere = data.purchasedSphere;
    }

    private void Save()
    {
        SaveManager.Save(SaveKey,GetSaveSnapshot());
        PlayerPrefs.Save();
    }

    private GameData GetSaveSnapshot()
    {
        var data = new GameData()
        {
            purchasedKnight = _purchasedKnight,
            selectedKnight = _selectedKnight,
            purchasedShield = _purchasedShield,
            purchasedSphere = _purchasedSphere
        };

        return data;
    }

    public bool IsPurchasedKnight(int index)
    {
        return _purchasedKnight[index];
    }

    public bool IsPurchasedShield()
    {
        return _purchasedShield;
    }

    public bool IsPurchasedSphere()
    {
        return _purchasedSphere;
    }

    public bool IsSelectedKnight(int index)
    {
        return _selectedKnight[index];
    }

    public void BuyShield()
    {
        _purchasedShield = true;
        Save();
    }

    public void BuySphere()
    {
        _purchasedSphere = true;
        Save();
    }

    public void BuyKnight(int index)
    {
        _purchasedKnight[index] = true;
    }

    public void SelectKnight(int index)
    {
        for (int i = 0; i < _selectedKnight.Length; i++)
        {
            if (i == index)
            {
                _selectedKnight[i] = true;
            }
            else
            {
                _selectedKnight[i] = false;
            }
        }
    }
}
