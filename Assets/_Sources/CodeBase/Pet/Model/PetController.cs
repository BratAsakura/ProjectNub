using System;
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
            if (_pet.State == PetState.Awake)
                ToggleSleep();
            else if (_pet.State == PetState.Sleeping)
                ToggleAwake();
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ToggleDead();
        }
    }

    private void ToggleSleep()
    {
        _pet.ChangeState(PetState.Sleeping);
    }

    private void ToggleAwake()
    {
        _pet.ChangeState(PetState.Awake);
    }

    private void ToggleDead()
    {
        _pet.ChangeState(PetState.Dead);
    }
}