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
        string path = Application.persistentDataPath + "/petSave.json";

        if (System.IO.File.Exists(path))
        {
            string json = System.IO.File.ReadAllText(path);
            PetSaveData data = JsonUtility.FromJson<PetSaveData>(json);
            _pet.LoadData(data);
            DateTime savedTime = DateTime.Parse(data.LastExitTime);
            DateTime realTime = DateTime.UtcNow;
            float timeNow = (float)(realTime - savedTime).TotalSeconds;
            _pet.Tick(timeNow * _config.OfflineMultiplier);
        }
    }

    private void Update()
    {
        _pet.Tick(Time.deltaTime * _timeScale);
    }

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void SaveGame()
    {
        string timeNow = DateTime.UtcNow.ToString();
        PetSaveData data = _pet.GetSaveData(timeNow);
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/petSave.json", json);
    }

    public void CreateNewPet()
    {
        string path = Application.persistentDataPath + "/petSave.json";
        
        if (System.IO.File.Exists(path))
        {
            System.IO.File.Delete(path);
        }

        _pet = new(_config.MaxValue, _config.MaxValue, _config.MaxValue, _config.MaxValue, _config);
    }

    public void Feed() => 
        _pet.TryFeed();

    public void Heal() => 
        _pet.TryHeal();

    public void Walk() => 
        _pet.TryWalk();

    public void SleepAndWakeUp()
    {
        if (_pet.State == PetState.Awake)
            _pet.TrySleep();
        else if (_pet.State == PetState.Sleeping)
            _pet.TryWakeUp();
    }
}