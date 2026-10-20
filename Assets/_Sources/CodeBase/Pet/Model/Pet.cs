public class Pet
{
    private ScaleModel _satiety; // Сытость
    private ScaleModel _health; // Здорвье
    private ScaleModel _happiness; // Счастье
    private ScaleModel _cheerfulness; // Бодрость

    public ScaleModel Satiety => _satiety;
    public ScaleModel Health => _health;
    public ScaleModel Happiness => _happiness;
    public ScaleModel Cheerfulness => _cheerfulness;

    public Pet(float satiety, float health, float happiness, float cheerfulness)
    {
        _satiety = new(satiety);
        _health = new(health);
        _happiness = new(happiness);
        _cheerfulness = new(cheerfulness);
    }
}