using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PetUI : MonoBehaviour
{
    [SerializeField] private PetController _petController;
    [SerializeField] private Slider _satietyBar;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _happinessBar;
    [SerializeField] private Slider _cheerfulnessBar;
    [SerializeField] private Button _feedButton;
    [SerializeField] private Button _healButton;
    [SerializeField] private Button _walkButton;
    [SerializeField] private Button _sleepButton;
    [SerializeField] private Button _createPetButton;
    [SerializeField] private GameObject _deadScene;
    [SerializeField] private GameObject _actionButtons;
    [SerializeField] private Button _backButton;

    private void Awake()
    {
        if (_petController == null)
            Debug.LogError("Не найдет контроллер");

        if (_satietyBar == null)
            Debug.LogError("Не найдет слайдер: Сытости");

        if (_healthBar == null)
            Debug.LogError("Не найдет слайдер: Жизни");

        if (_happinessBar == null)
            Debug.LogError("Не найдет слайдер: Счастья");

        if (_cheerfulnessBar == null)
            Debug.LogError("Не найдет слайдер: Бодрости");

        if (_feedButton == null)
            Debug.LogError("Не найдена кнопка: Поесть");

        if (_healButton == null)
            Debug.LogError("Не найдена кнопка: Полечить");

        if (_walkButton == null)
            Debug.LogError("Не найдена кнопка: Погулять");

        if (_sleepButton == null)
            Debug.LogError("Не найдена кнопка: Сон/Пробуждение");

        if (_createPetButton == null)
            Debug.LogError("Не найдена кнопка: Создание питомца.");

        if (_deadScene == null)
            Debug.LogError("Не найдена сцена смерти.");

        if (_actionButtons == null)
            Debug.LogError("Не найдены кнопки действий.");

        if (_backButton == null)
            Debug.LogError("Не найдены кнопки Назад.");
    }

    public void Start()
    {
        _satietyBar.value = _petController.Pet.Satiety.CurrentValue;
        _healthBar.value = _petController.Pet.Health.CurrentValue;
        _happinessBar.value = _petController.Pet.Happiness.CurrentValue;
        _cheerfulnessBar.value = _petController.Pet.Cheerfulness.CurrentValue;
        
        if (_petController.Pet.State != PetState.Dead)
            _deadScene.SetActive(false);
        else
            _deadScene.SetActive(true);

        if (_petController.Pet.State != PetState.Dead)
            _actionButtons.SetActive(true);
        else
            _actionButtons.SetActive(false);
    }

    private void OnEnable()
    {
        _feedButton.onClick.AddListener(OnFeedClicked);
        _healButton.onClick.AddListener(OnHealClicked);
        _walkButton.onClick.AddListener(OnWalkClicked);
        _sleepButton.onClick.AddListener(OnSleepClicked);
        _createPetButton.onClick.AddListener(OnCreateClicked);
        _backButton.onClick.AddListener(OnBackClicked);
    }

    private void OnBackClicked()
    {
        _petController.SaveGame();
        SceneManager.LoadScene("MainMenu");
    }

    private void OnCreateClicked()
    {
        _petController.CreateNewPet();
        _deadScene.SetActive(false);
        _actionButtons.SetActive(true);
    }

    private void OnSleepClicked()
    {
        _petController.SleepAndWakeUp();
    }

    private void OnWalkClicked()
    {
        _petController.Walk();
    }

    private void OnHealClicked()
    {
        _petController.Heal();
    }

    private void OnFeedClicked()
    {
        _petController.Feed();
    }

    private void OnDestroy()
    {
        _feedButton.onClick.RemoveListener(OnFeedClicked);
        _healButton.onClick.RemoveListener(OnHealClicked);
        _walkButton.onClick.RemoveListener(OnWalkClicked);
        _sleepButton.onClick.RemoveListener(OnSleepClicked);
        _createPetButton.onClick.RemoveListener(OnCreateClicked);
        _backButton.onClick.RemoveListener(OnBackClicked);
    }

    private void Update()
    {
        _satietyBar.value = _petController.Pet.Satiety.CurrentValue;
        _healthBar.value = _petController.Pet.Health.CurrentValue;
        _happinessBar.value = _petController.Pet.Happiness.CurrentValue;
        _cheerfulnessBar.value = _petController.Pet.Cheerfulness.CurrentValue;

        if (_petController.Pet.State == PetState.Dead)
        {
            _deadScene.SetActive(true);
            _actionButtons.SetActive(false);
        }
    }
}