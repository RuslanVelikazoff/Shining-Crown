using UnityEngine;

public class AchievementsData : MonoBehaviour
{
    private const string SaveKey = "MainSaveAchievements";

    private bool[] _achievementComplete;

    public static AchievementsData Instance;

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

        _achievementComplete = data.achievementComplete;
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
            achievementComplete = _achievementComplete
        };

        return data;
    }

    public bool IsAchievementComplete(int index)
    {
        return _achievementComplete[index];
    }
}
