public class Pet
{
    private ScaleModel _satiety; // Сытость
    private ScaleModel _health; // Здорвье
    private ScaleModel _happiness; // Счастье
    private ScaleModel _cheerfulness; // Бодрость
    private PetConfig _petConfig;

    public ScaleModel Satiety => _satiety;
    public ScaleModel Health => _health;
    public ScaleModel Happiness => _happiness;
    public ScaleModel Cheerfulness => _cheerfulness;

    public Pet(float satiety, float health, float happiness, float cheerfulness, PetConfig config)
    {
        _satiety = new(satiety);
        _health = new(health);
        _happiness = new(happiness);
        _cheerfulness = new(cheerfulness);
        _petConfig = config;
    }

    public void Tick(float deltaTime)
    {
        _satiety.ReduceValue(deltaTime * _petConfig.SatietyDecayRate);
        _health.ReduceValue(deltaTime * _petConfig.HealthDecayRate);
        _happiness.ReduceValue(deltaTime * _petConfig.HappinessDecayRate);
        _cheerfulness.ReduceValue(deltaTime * _petConfig.CheerfulnessDecayRate);
    }
}