using UnityEngine;
using UnityEngine.UI;

public class PetUI : MonoBehaviour
{
    [SerializeField] private PetController _petController;
    [SerializeField] private Slider _satietyBar;
    [SerializeField] private Slider _healthBar;
    [SerializeField] private Slider _happinessBar;
    [SerializeField] private Slider _cheerfulnessBar;

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
    }

    public void Start()
    {
        _satietyBar.value = _petController.Pet.Satiety.CurrentValue;
        _healthBar.value = _petController.Pet.Health.CurrentValue;
        _happinessBar.value = _petController.Pet.Happiness.CurrentValue;
        _cheerfulnessBar.value = _petController.Pet.Cheerfulness.CurrentValue;

    }

    private void Update()
    {
        _satietyBar.value = _petController.Pet.Satiety.CurrentValue;
        _healthBar.value = _petController.Pet.Health.CurrentValue;
        _happinessBar.value = _petController.Pet.Happiness.CurrentValue;
        _cheerfulnessBar.value = _petController.Pet.Cheerfulness.CurrentValue;
    }
}