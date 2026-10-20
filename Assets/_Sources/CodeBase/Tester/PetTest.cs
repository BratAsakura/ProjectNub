using UnityEngine;

public class PetTest : MonoBehaviour
{
    [SerializeField] private float _valueTesting;
    private ScaleModel _scale;

    private void Awake()
    {
        _scale = new(_valueTesting);    
    }

    private void Start()
    {
        Debug.Log($"Стартовое значение: {_scale.CurrentValue}");
        _scale.AddValue(34);
        Debug.Log($"Текущие значение (увеличилось): {_scale.CurrentValue}");
        _scale.AddValue(1023);
        Debug.Log($"Текущие значение (Максимальное): {_scale.CurrentValue}");
        _scale.ReduceValue(22);
        Debug.Log($"Текущие значение (уменьшилось): {_scale.CurrentValue}");
        _scale.ReduceValue(120);
        Debug.Log($"Текущие значение (минимальное): {_scale.CurrentValue}");
        _scale.AddValue(50);
        Debug.Log($"Окончательное значение: {_scale.CurrentValue}");

    }
}
