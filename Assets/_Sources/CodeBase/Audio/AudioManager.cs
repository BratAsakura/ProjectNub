using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [SerializeField] private AudioSource _sfxSource;
    [SerializeField] private AudioSource _musicSource;
    [SerializeField] private AudioClip _clickClip;
    [SerializeField] private AudioClip _musicClip;

    public AudioSource SFXSource => _sfxSource;
    public AudioSource MusicSource => _musicSource;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        if (_sfxSource == null)
            Debug.LogError("Не установленна аудио Source");

        if (_musicSource == null)
            Debug.LogError("Не установленна музыка Source");

        if (_clickClip == null)
            Debug.LogError("Не установлен клик");

        if (_musicClip == null)
            Debug.LogError("Не установлен музыка");
    }

    private void Start()
    {
        _musicSource.PlayOneShot(_musicClip);
    }

    public void PlayClick()
    {
        _sfxSource.PlayOneShot(_clickClip);
    }

    public void SetMusicVolume(float value)
    {
        _musicSource.volume = value;
        PlayerPrefs.SetFloat("MusicVolume", _musicSource.volume);
    }

    public void SetSFXVolume(float value)
    {
        _sfxSource.volume = value;
        PlayerPrefs.SetFloat("SFXVolume", _sfxSource.volume);
    }
}
