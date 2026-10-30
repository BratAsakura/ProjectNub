using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private Button _exitSettingsButton;

    [SerializeField] private Slider _musicSlide;
    [SerializeField] private Slider _sfxSlide;

    private void Awake()
    {
        if (_playButton == null)
            Debug.LogError("Не установленна кнопка: Играть");

        if (_settingsButton == null)
            Debug.LogError("Не установленна кнопка: Настройки");

        if (_deleteButton == null)
            Debug.LogError("Не установленна кнопка: Удаление персонажа");

        if (_exitButton == null)
            Debug.LogError("Не установленна кнопка: Выхода");

        if (_settingsPanel == null)
            Debug.LogError("Не найден панель настройки");

        if (_exitSettingsButton == null)
            Debug.LogError("Не установленна кнопка: Выхода из настройки");

        if (_musicSlide == null)
            Debug.LogError("Не найден слайдер Музыки");

        if (_sfxSlide == null)
            Debug.LogError("Не найден слайдер Звуков");
    }

    private void Start()
    {
        _settingsPanel.SetActive(false);

        if (PlayerPrefs.HasKey("MusicVolume"))
        {
            AudioManager.Instance.SetMusicVolume(PlayerPrefs.GetFloat("MusicVolume"));
            _musicSlide.value = PlayerPrefs.GetFloat("MusicVolume");
        }
        else
        {
            AudioManager.Instance.SetMusicVolume(_musicSlide.value);
        }

        if (PlayerPrefs.HasKey("SFXVolume"))
        {
            AudioManager.Instance.SetSFXVolume(PlayerPrefs.GetFloat("SFXVolume"));
            _sfxSlide.value = PlayerPrefs.GetFloat("SFXVolume");
        }
        else
        {
            AudioManager.Instance.SetSFXVolume(_sfxSlide.value);
        }
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayClicked);
        _settingsButton.onClick.AddListener(OnSettingsClicked);
        _deleteButton.onClick.AddListener(OnDeleteClicked);
        _exitButton.onClick.AddListener(OnExitClicked);
        _exitSettingsButton.onClick.AddListener(OnExitSettingsClicked);
        _musicSlide.onValueChanged.AddListener(OnMusicChange);
        _sfxSlide.onValueChanged.AddListener(OnSFXChange);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(OnPlayClicked);
        _settingsButton.onClick.RemoveListener(OnSettingsClicked);
        _deleteButton.onClick.RemoveListener(OnDeleteClicked);
        _exitButton.onClick.RemoveListener(OnExitClicked);
        _exitSettingsButton.onClick.RemoveListener(OnExitSettingsClicked);
        _musicSlide.onValueChanged.RemoveListener(OnMusicChange);
        _sfxSlide.onValueChanged.RemoveListener(OnSFXChange);
    }

    private void OnExitClicked()
    {
        AudioManager.Instance.PlayClick();
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void OnExitSettingsClicked()
    {
        AudioManager.Instance.PlayClick();
        _settingsPanel.SetActive(false);
        _deleteButton.interactable = true;
        _exitButton.interactable = true;
        _playButton.interactable = true;
        _settingsButton.interactable = true;
    }

    private void OnDeleteClicked()
    {
        string path = Application.persistentDataPath + "/petSave.json";
        AudioManager.Instance.PlayClick();

        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
            Debug.Log("Персонаж удален");
        }
        else
        {
            Debug.Log("Персонаж не найден.");
        }

    }

    private void OnSettingsClicked()
    {
        AudioManager.Instance.PlayClick();
        _settingsPanel.SetActive(true);
        _deleteButton.interactable = false;
        _exitButton.interactable = false;
        _playButton.interactable = false;
        _settingsButton.interactable = false;
    }

    private void OnPlayClicked()
    {
        AudioManager.Instance.PlayClick();
        SceneManager.LoadScene("TestScene");
    }

    private void OnMusicChange(float value) =>
        AudioManager.Instance.SetMusicVolume(value);

    private void OnSFXChange(float value) =>
        AudioManager.Instance.SetSFXVolume(value);
}