using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField]
    private Button backButton;
    [SerializeField] 
    private Button saveButton;
    [SerializeField]
    private GameObject mainPanel;

    [Space(13)]
    
    [SerializeField]
    private Slider musicSlider;
    [SerializeField] 
    private Slider soundSlider;
    [SerializeField]
    private Slider controlSlider;

    [Space(13)]
    
    [SerializeField] 
    private TMP_Dropdown modelDropDown;
    [SerializeField] 
    private TMP_Dropdown textureDropDown;
    [SerializeField] 
    private TMP_Dropdown shadowDropDown;

    private float musicVolume;
    private float soundVolume;
    private float controlVolume;
    private int selectedModelIndex;
    private int selectedTextureIndex;
    private int selectedShadowIndex;

    private const string PLAYER_PREFS_CONTROL_VOLUME = "ControlVolume";
    private const string PLAYER_PREFS_MODEL_INDEX = "ModelIndex";
    private const string PLAYER_PREFS_TEXTURE_INDEX = "TextureIndex";
    private const string PLAYER_PREFS_SHADOW_INDEX = "ShadowIndex";

    private void Awake()
    {
        SettingsButtonClickAction();
    }

    private void OnEnable()
    {
        SetSettingsValue();
    }

    public void MusicVolumeSlider()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
    }

    public void SoundVolumeSlider()
    {
        AudioManager.Instance.SetSoundVolume(soundSlider.value);
    }

    private void SettingsButtonClickAction()
    {
        if (backButton != null)
        {
            backButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
                ResetSettings();
            });
        }

        if (saveButton != null)
        {
            saveButton.onClick.AddListener(() =>
            {
                this.gameObject.SetActive(false);
                mainPanel.SetActive(true);
                SaveSettings();
            });
        }
    }

    private void SetSettingsValue()
    {
        musicVolume = AudioManager.Instance.GetMusicVolume();
        soundVolume = AudioManager.Instance.GetSoundVolume();
        controlVolume = PlayerPrefs.GetFloat(PLAYER_PREFS_CONTROL_VOLUME, 1f);

        selectedModelIndex = PlayerPrefs.GetInt(PLAYER_PREFS_MODEL_INDEX, 0);
        selectedTextureIndex = PlayerPrefs.GetInt(PLAYER_PREFS_TEXTURE_INDEX, 0);
        selectedShadowIndex = PlayerPrefs.GetInt(PLAYER_PREFS_SHADOW_INDEX, 0);

        musicSlider.value = musicVolume;
        soundSlider.value = soundVolume;
        controlSlider.value = controlVolume;

        modelDropDown.value = selectedModelIndex;
        textureDropDown.value = selectedTextureIndex;
        shadowDropDown.value = selectedShadowIndex;
    }

    private void SaveSettings()
    {
        AudioManager.Instance.SetMusicVolume(musicSlider.value);
        AudioManager.Instance.SetSoundVolume(soundSlider.value);
        PlayerPrefs.SetFloat(PLAYER_PREFS_CONTROL_VOLUME, controlSlider.value);
        
        PlayerPrefs.SetInt(PLAYER_PREFS_MODEL_INDEX, modelDropDown.value);
        PlayerPrefs.SetInt(PLAYER_PREFS_TEXTURE_INDEX, textureDropDown.value);
        PlayerPrefs.SetInt(PLAYER_PREFS_SHADOW_INDEX, shadowDropDown.value);
        
    }

    private void ResetSettings()
    {
        AudioManager.Instance.SetMusicVolume(musicVolume);
        AudioManager.Instance.SetSoundVolume(soundVolume);
        PlayerPrefs.SetFloat(PLAYER_PREFS_CONTROL_VOLUME, controlVolume);

        PlayerPrefs.SetInt(PLAYER_PREFS_MODEL_INDEX, selectedModelIndex);
        PlayerPrefs.SetInt(PLAYER_PREFS_TEXTURE_INDEX, selectedTextureIndex);
        PlayerPrefs.SetInt(PLAYER_PREFS_SHADOW_INDEX, selectedShadowIndex);
    }
}
