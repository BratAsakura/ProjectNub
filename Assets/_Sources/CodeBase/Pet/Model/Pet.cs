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
        _satiety = new(satiety);
        _health = new(health);
        _happiness = new(happiness);
        _cheerfulness = new(cheerfulness);
        _config = config;
        _state = state;
    }

    public void Tick(float deltaTime)
    {
        _satiety.ReduceValue(deltaTime * _config.SatietyDecayRate);
        _health.ReduceValue(deltaTime * _config.HealthDecayRate);
        _happiness.ReduceValue(deltaTime * _config.HappinessDecayRate);
        _cheerfulness.ReduceValue(deltaTime * _config.CheerfulnessDecayRate);
    }

    public void ChangeState(PetState state)
    {
        _state = state;
    }
}