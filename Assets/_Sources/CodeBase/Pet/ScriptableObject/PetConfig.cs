using UnityEngine;

[CreateAssetMenu(fileName = "PetConfig", menuName = "Tamagotchi/Pet Config")]
public class PetConfig : ScriptableObject
{
    [Header("Максимальное и минимальное значение")]
    [SerializeField] private float _maxValue;
    [SerializeField] private float _minValue;
    [Header("Скорость падения шкалы")]
    [SerializeField] private float _satietyDecayRate = 0.00694f; // 4 часа
    [SerializeField] private float _healthDecayRate = 0;
    [SerializeField] private float _happinessDecayRate = 0.00231f; // 12 Часов
    [SerializeField] private float _cheerfulnessDecayRate = 0.00347f; // 8 Часов
    [Header("Оффлайн")]
    [SerializeField] private float _offlineMultiplier = 0.3f;

    public float MaxValue => _maxValue;
    public float MinValue => _minValue;
    public float SatietyDecayRate => _satietyDecayRate;
    public float HealthDecayRate => _healthDecayRate;
    public float HappinessDecayRate => _happinessDecayRate;
    public float CheerfulnessDecayRate => _cheerfulnessDecayRate;
    public float OfflineMultiplier => _offlineMultiplier;
}