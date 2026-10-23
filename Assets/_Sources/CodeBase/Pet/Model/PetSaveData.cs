[System.Serializable]
public class PetSaveData
{
    public float Satiety;
    public float Health;
    public float Happiness;
    public float Cheerfulness;
    public PetState State;
    public string LastExitTime;

    public PetSaveData(float satiety, float health, float happiness, float cheerfulness, PetState state, string lastExitTime)
    {
        Satiety = satiety;
        Health = health;
        Happiness = happiness;
        Cheerfulness = cheerfulness;
        State = state;
        LastExitTime = lastExitTime;
    }
}