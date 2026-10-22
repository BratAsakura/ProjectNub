using UnityEngine;

public class PetController : MonoBehaviour
{
    [SerializeField] private PetConfig _config;
    [SerializeField] private float _timeScale = 1f;
    private Pet _pet;
    public Pet Pet => _pet;

    private void Awake()
    {
        _pet = new(_config.MaxValue, _config.MaxValue, _config.MaxValue, _config.MaxValue, _config);
    }

    private void Update()
    {
        _pet.Tick(Time.deltaTime * _timeScale);

        if (Input.GetKeyDown(KeyCode.S))
        {
            if (_pet.TrySleep())
                Debug.Log("Уснул.");
            else if (_pet.TryWakeUp())
                Debug.Log("Проснулся.");
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ToggleDead();
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            _pet.TryFeed();
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            _pet.TryWalk();
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            _pet.TryHeal();
        }
    }

    private void ToggleDead() =>
        _pet.ChangeState(PetState.Dead);
}