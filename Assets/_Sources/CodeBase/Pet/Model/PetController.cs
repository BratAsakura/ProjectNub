using System;
using UnityEngine;

public class PetController : MonoBehaviour
{
    [SerializeField] private PetConfig _config;
    [SerializeField] private float _timeScale = 1f;
    [SerializeField] private Animator _animatorPlayer;
    [SerializeField] private float _animSpeed = 1f;

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

        if (_animatorPlayer == null)
            Debug.LogError("Не найден Аниматор.");

        _animatorPlayer.speed = _animSpeed;

        if (_pet.State == PetState.Sleeping)
        {
            _animatorPlayer.Play("Sleep", 0, 0f);
            _animatorPlayer.SetBool("IsSleeping", true);
            _animatorPlayer.SetBool("IsWakeUp", false);
        }
        else
        {
            _animatorPlayer.SetBool("IsSleeping", false);
            _animatorPlayer.SetBool("IsWakeUp", true);
        }
    }

    private void Update()
    {
        _pet.Tick(Time.deltaTime * _timeScale);

        if (_pet.Cheerfulness.CurrentValue == _config.MaxValue && _pet.State == PetState.Sleeping)
        {
            SleepAndWakeUp();
        }
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
        {
            _animatorPlayer.SetBool("IsSleeping", true);
            _animatorPlayer.SetBool("IsWakeUp", false);
            _pet.TrySleep();
        }
        else if (_pet.State == PetState.Sleeping)
        {
            _animatorPlayer.SetBool("IsSleeping", false);
            _animatorPlayer.SetBool("IsWakeUp", true);
            _pet.TryWakeUp();
        }
    }
}