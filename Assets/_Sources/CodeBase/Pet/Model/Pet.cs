public class Pet
{
    private ScaleModel _satiety; // Сытость
    private ScaleModel _health; // Здорвье
    private ScaleModel _happiness; // Счастье
    private ScaleModel _cheerfulness; // Бодрость
    private PetConfig _config;
    private PetState _state;

    public ScaleModel Satiety => _satiety;
    public ScaleModel Health => _health;
    public ScaleModel Happiness => _happiness;
    public ScaleModel Cheerfulness => _cheerfulness;
    public PetState State => _state;

    public Pet(float satiety, float health, float happiness, float cheerfulness, PetConfig config, PetState state = PetState.Awake)
    {
        _config = config;
        _state = state;
        _satiety = new(satiety, _config.MaxValue);
        _health = new(health, _config.MaxValue);
        _happiness = new(happiness, _config.MaxValue);
        _cheerfulness = new(cheerfulness, _config.MaxValue);
    }

    public void Tick(float deltaTime)
    {
        if(_state == PetState.Awake)
        {
            _satiety.ReduceValue(deltaTime * _config.SatietyDecayRate);
            _health.ReduceValue(deltaTime * _config.HealthDecayRate);
            _happiness.ReduceValue(deltaTime * _config.HappinessDecayRate);
            _cheerfulness.ReduceValue(deltaTime * _config.CheerfulnessDecayRate);

            if (_satiety.CurrentValue <= 0 || _cheerfulness.CurrentValue <= 0)
            {
                _health.ReduceValue(deltaTime * _config.CriticalHealthDecayRate);
            }
        }
        else if (_state == PetState.Sleeping)
        {
            _satiety.ReduceValue(deltaTime * _config.SatietyDecayRate * _config.SleepDecayMultiplier);
            _health.ReduceValue(deltaTime * _config.HealthDecayRate * _config.SleepDecayMultiplier);
            _happiness.ReduceValue(deltaTime * _config.HappinessDecayRate * _config.SleepDecayMultiplier);
            _cheerfulness.AddValue(deltaTime * _config.SleepCheerfulnessGain);

            if (_satiety.CurrentValue <= 0 || _cheerfulness.CurrentValue <= 0)
            {
                _health.ReduceValue(deltaTime * _config.CriticalHealthDecayRate);
            }
        }
        else
        {
            return;
        }

        if (_health.CurrentValue <= 0)
        {
            ChangeState(PetState.Dead);
        }
    }

    public void ChangeState(PetState state)
    {
        _state = state;
    }

    public bool TryFeed()
    {
        if (IsActive())
        {
            _satiety.AddValue(_config.FeedAmount);
            return true;
        }

        return false;
    }

    public bool TryHeal()
    {
        if (IsActive())
        {
            _health.AddValue(_config.HealAmount);
            return true;
        }

        return false;
    }

    public bool TryWalk()
    {
        if (IsActive())
        {
            if (_cheerfulness.CurrentValue >= _config.WalkHappinessAmount)
            {
                _happiness.AddValue(_config.WalkHappinessAmount);
                _cheerfulness.ReduceValue(_config.WalkCheerfulnessCost);
                return true;
            }
        }

        return false;
    }

    public bool TrySleep()
    {
        if (IsActive())
        {
            ChangeState(PetState.Sleeping);
            return true;
        }

        return false;
    }

    public bool TryWakeUp()
    {
        if (_state != PetState.Dead && _state == PetState.Sleeping)
        {
            ChangeState(PetState.Awake);
            return true;
        }

        return false;
    }

    private bool IsActive() => 
        _state != PetState.Dead && _state != PetState.Sleeping;

    public PetSaveData GetSaveData(string lastExitTime)
    {
        return new PetSaveData(
            _satiety.CurrentValue,
            _health.CurrentValue,
            _happiness.CurrentValue,
            _cheerfulness.CurrentValue,
            _state,
            lastExitTime
        );
    }

    public void LoadData(PetSaveData data)
    {
        _satiety.SetValue(data.Satiety);
        _health.SetValue(data.Health);
        _happiness.SetValue(data.Happiness);
        _cheerfulness.SetValue(data.Cheerfulness);
        _state = data.State;
    }
}