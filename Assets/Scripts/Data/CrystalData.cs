using UnityEngine;

public class CrystalData : MonoBehaviour
{
    private const string SaveKey = "MainSaveCrystal";

    private int _crystal;

    public static CrystalData Instance;

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

        _crystal = data.crystal;
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
            crystal = _crystal
        };

        return data;
    }

    public int GetCrystalAmount()
    {
        return _crystal;
    }

    public void MinusCrystal(int amount)
    {
        _crystal -= amount;
        Save();
    }

    public void PlusCrystal(int amount)
    {
        _crystal += amount;
        Save();
    }
}
