using UnityEngine;

public class PetTest : MonoBehaviour
{
    [SerializeField] private float _valueTesting;
    private Pet _pet;

    private void Awake()
    {
        _pet = new(_valueTesting, _valueTesting, _valueTesting, _valueTesting);    
    }

    private void Start()
    {
        Debug.Log($"Стартовые значения:\nСытость: {_pet.Satiety.CurrentValue}\nЗдоровье: {_pet.Health.CurrentValue}\nСчастье: {_pet.Happiness.CurrentValue}\nБодрость: {_pet.Cheerfulness.CurrentValue}");
        _pet.Happiness.ReduceValue(30.4f);
        Debug.Log($"Текущие значения:\nСытость: {_pet.Satiety.CurrentValue}\nЗдоровье: {_pet.Health.CurrentValue}\nСчастье: {_pet.Happiness.CurrentValue}\nБодрость: {_pet.Cheerfulness.CurrentValue}");
        _pet.Happiness.AddValue(20.3f);
        _pet.Cheerfulness.ReduceValue(64.3f);
        Debug.Log($"Изменеено 2 значения:\nСытость: {_pet.Satiety.CurrentValue}\nЗдоровье: {_pet.Health.CurrentValue}\nСчастье: {_pet.Happiness.CurrentValue}\nБодрость: {_pet.Cheerfulness.CurrentValue}");
        _pet.Health.ReduceValue(300);
        _pet.Cheerfulness.AddValue(200);
        Debug.Log($"Макс и мин значения:\nСытость: {_pet.Satiety.CurrentValue}\nЗдоровье: {_pet.Health.CurrentValue}\nСчастье: {_pet.Happiness.CurrentValue}\nБодрость: {_pet.Cheerfulness.CurrentValue}");
    }
}
