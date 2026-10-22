using UnityEngine;

public class PetTest : MonoBehaviour
{
    [SerializeField] private PetController _petController;
    [SerializeField] private float _timeDebug = 1f;
    private float _time = 0;

    private void Start()
    {
        Debug.Log($"Стартовые значения:\nСытость: {_petController.Pet.Satiety.CurrentValue}\nЗдоровье: {_petController.Pet.Health.CurrentValue}\nСчастье: {_petController.Pet.Happiness.CurrentValue}\nБодрость: {_petController.Pet.Cheerfulness.CurrentValue}");
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if(_time >= _timeDebug)
        {
            Debug.Log($"Текущие значения:\nСытость: {_petController.Pet.Satiety.CurrentValue}\nЗдоровье: {_petController.Pet.Health.CurrentValue}\nСчастье: {_petController.Pet.Happiness.CurrentValue}\nБодрость: {_petController.Pet.Cheerfulness.CurrentValue}");
            Debug.Log($"Статус петомца: {_petController.Pet.State}");
            _time = 0;
        }
    }
}