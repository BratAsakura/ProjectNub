using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    [SerializeField] private Button _playButton;
    [SerializeField] private Button _settingsButton;
    [SerializeField] private Button _deleteButton;
    [SerializeField] private Button _exitButton;

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
    }

    private void OnEnable()
    {
        _playButton.onClick.AddListener(OnPlayClicked);
        _settingsButton.onClick.AddListener(OnSettingsClicked);
        _deleteButton.onClick.AddListener(OnDeleteClicked);
        _exitButton.onClick.AddListener(OnExitClicked);
    }

    private void OnDestroy()
    {
        _playButton.onClick.RemoveListener(OnPlayClicked);
        _settingsButton.onClick.RemoveListener(OnSettingsClicked);
        _deleteButton.onClick.RemoveListener(OnDeleteClicked);
        _exitButton.onClick.RemoveListener(OnExitClicked);
    }

    private void OnExitClicked()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    private void OnDeleteClicked()
    {
        string path = Application.persistentDataPath + "/petSave.json";

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
        Debug.Log("Открыты настройки.");
    }

    private void OnPlayClicked()
    {
        SceneManager.LoadScene("TestScene");
    }
}
