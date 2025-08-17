using UnityEngine;

/// <summary>
/// ���� ���带 �����ϴ� �̱��� Ŭ����
/// </summary>
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    [Header("����� �ҽ�")]
    public AudioSource musicSource;
    public AudioSource effectSource;

    [Header("���� Ŭ��")]
    public AudioClip backgroundMusic;
    public AudioClip coinSound;

    [Header("���� ����")]
    [Range(0f, 1f)]
    public float musicVolume = 0.5f;
    [Range(0f, 1f)]
    public float effectVolume = 0.8f;

    public static SoundManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<SoundManager>();

                if (_instance == null)
                {
                    GameObject soundObject = new GameObject("SoundManager");
                    _instance = soundObject.AddComponent<SoundManager>();
                    _instance.InitializeAudioSources();
                }
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeAudioSources();
        }
        else if (_instance != this)
        {
            Destroy(gameObject);
        }
    }

    private void InitializeAudioSources()
    {
        // ������ǿ� AudioSource ����
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true; // ��������� �ݺ����
            musicSource.volume = musicVolume;
            musicSource.playOnAwake = false; // �ڵ���� ����
        }

        // ȿ������ AudioSource ����  
        if (effectSource == null)
        {
            effectSource = gameObject.AddComponent<AudioSource>();
            effectSource.loop = false; // ȿ������ �ѹ��� ���
            effectSource.volume = effectVolume;
            effectSource.playOnAwake = false; // �ڵ���� ����
        }
    }

    // ������� ���
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && musicSource != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    // ������� ����
    public void StopBackgroundMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    // ȿ���� ���
    public void PlayEffectSound(AudioClip clip)
    {
        if (clip != null && effectSource != null)
        {
            effectSource.PlayOneShot(clip);
        }
    }

    // ���� ���� ����
    public void PlayCoinSound()
    {
        PlayEffectSound(coinSound);
    }

    // ���� ���� ����
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        if (musicSource != null)
        {
            musicSource.volume = musicVolume;
        }
    }

    // ȿ���� ���� ����
    public void SetEffectVolume(float volume)
    {
        effectVolume = Mathf.Clamp01(volume);
        if (effectSource != null)
        {
            effectSource.volume = effectVolume;
        }
    }

    // ��� ���� ���Ұ�
    public void MuteAll()
    {
        if (musicSource != null) musicSource.mute = true;
        if (effectSource != null) effectSource.mute = true;
    }

    // ���Ұ� ����
    public void UnmuteAll()
    {
        if (musicSource != null) musicSource.mute = false;
        if (effectSource != null) effectSource.mute = false;
    }
}