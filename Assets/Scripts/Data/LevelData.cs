using UnityEngine;

public class LevelData : MonoBehaviour
{
    private const string SaveKey = "MainSaveLevel";

    private bool[] _levelUnlock;
    private bool[] _levelCompleted;

    public static LevelData Instance;

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

        _levelUnlock = data.levelUnlock;
        _levelCompleted = data.levelCompleted;
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
            levelUnlock = _levelUnlock,
            levelCompleted = _levelCompleted
        };

        return data;
    }

    public bool IsLevelUnlock(int index)
    {
        return _levelUnlock[index];
    }

    public bool IsLevelCompleted(int index)
    {
        return _levelCompleted[index];
    }
}
