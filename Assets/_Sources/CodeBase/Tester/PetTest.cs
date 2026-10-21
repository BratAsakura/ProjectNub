using UnityEngine;

public class PetTest : MonoBehaviour
{
    [SerializeField] private PetController _petController;

    private void Start()
    {
        Debug.Log($"Стартовые значения:\nСытость: {_petController.Pet.Satiety.CurrentValue}\nЗдоровье: {_petController.Pet.Health.CurrentValue}\nСчастье: {_petController.Pet.Happiness.CurrentValue}\nБодрость: {_petController.Pet.Cheerfulness.CurrentValue}");
    }

    private void Update()
    {
        Debug.Log(_petController.Pet.State);
        //Debug.Log($"Текущие значения:\nСытость: {_petController.Pet.Satiety.CurrentValue}\nЗдоровье: {_petController.Pet.Health.CurrentValue}\nСчастье: {_petController.Pet.Happiness.CurrentValue}\nБодрость: {_petController.Pet.Cheerfulness.CurrentValue}");
    }
}