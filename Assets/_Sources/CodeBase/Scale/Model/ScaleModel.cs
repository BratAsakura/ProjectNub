using UnityEngine;

public class ScaleModel
{
    public const float MaxValue = 100.0f;

    private float _currentValue;

    public float CurrentValue => _currentValue;

    public ScaleModel(float currentValue)
    {
        _currentValue = Mathf.Clamp(currentValue, 0, MaxValue);
    }

    public void AddValue(float value)
    {
        _currentValue = Mathf.Min(MaxValue, _currentValue + value);
    }

    public void ReduceValue(float value)
    {
        _currentValue = Mathf.Max(0, _currentValue - value);
    }
}