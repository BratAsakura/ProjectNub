using UnityEngine;

public class ScaleModel
{
    private readonly float _maxValue;

    private float _currentValue;

    public float CurrentValue => _currentValue;

    public ScaleModel(float currentValue, float maxValue)
    {
        _maxValue = maxValue;
        _currentValue = Mathf.Clamp(currentValue, 0, _maxValue);
    }

    public void AddValue(float value)
    {
        _currentValue = Mathf.Min(_maxValue, _currentValue + value);
    }

    public void ReduceValue(float value)
    {
        _currentValue = Mathf.Max(0, _currentValue - value);
    }

    public void SetValue(float value)
    {
        _currentValue = Mathf.Clamp(value, 0, _maxValue);
    }
}