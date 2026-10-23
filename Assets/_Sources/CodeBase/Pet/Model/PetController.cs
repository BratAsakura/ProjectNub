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

    private void OnApplicationQuit()
    {
        SaveGame();
    }

    public void SaveGame()
    {
        string timeNow = System.DateTime.UtcNow.ToString();
        PetSaveData data = _pet.GetSaveData(timeNow);
        string json = JsonUtility.ToJson(data);
        System.IO.File.WriteAllText(Application.persistentDataPath + "/petSave.json", json);
    }

    private void ToggleDead() =>
        _pet.ChangeState(PetState.Dead);
}