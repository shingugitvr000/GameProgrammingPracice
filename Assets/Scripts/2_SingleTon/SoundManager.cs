using UnityEngine;

/// <summary>
/// 게임 사운드를 관리하는 싱글턴 클래스
/// </summary>
public class SoundManager : MonoBehaviour
{
    private static SoundManager _instance;

    [Header("오디오 소스")]
    public AudioSource musicSource;
    public AudioSource effectSource;

    [Header("사운드 클립")]
    public AudioClip backgroundMusic;
    public AudioClip coinSound;

    [Header("볼륨 설정")]
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
        // 배경음악용 AudioSource 생성
        if (musicSource == null)
        {
            musicSource = gameObject.AddComponent<AudioSource>();
            musicSource.loop = true; // 배경음악은 반복재생
            musicSource.volume = musicVolume;
            musicSource.playOnAwake = false; // 자동재생 방지
        }

        // 효과음용 AudioSource 생성  
        if (effectSource == null)
        {
            effectSource = gameObject.AddComponent<AudioSource>();
            effectSource.loop = false; // 효과음은 한번만 재생
            effectSource.volume = effectVolume;
            effectSource.playOnAwake = false; // 자동재생 방지
        }
    }

    // 배경음악 재생
    public void PlayBackgroundMusic()
    {
        if (backgroundMusic != null && musicSource != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    // 배경음악 정지
    public void StopBackgroundMusic()
    {
        if (musicSource != null && musicSource.isPlaying)
        {
            musicSource.Stop();
        }
    }

    // 효과음 재생
    public void PlayEffectSound(AudioClip clip)
    {
        if (clip != null && effectSource != null)
        {
            effectSource.PlayOneShot(clip);
        }
    }

    // 동전 수집 사운드
    public void PlayCoinSound()
    {
        PlayEffectSound(coinSound);
    }

    // 음악 볼륨 설정
    public void SetMusicVolume(float volume)
    {
        musicVolume = Mathf.Clamp01(volume);
        if (musicSource != null)
        {
            musicSource.volume = musicVolume;
        }
    }

    // 효과음 볼륨 설정
    public void SetEffectVolume(float volume)
    {
        effectVolume = Mathf.Clamp01(volume);
        if (effectSource != null)
        {
            effectSource.volume = effectVolume;
        }
    }

    // 모든 사운드 음소거
    public void MuteAll()
    {
        if (musicSource != null) musicSource.mute = true;
        if (effectSource != null) effectSource.mute = true;
    }

    // 음소거 해제
    public void UnmuteAll()
    {
        if (musicSource != null) musicSource.mute = false;
        if (effectSource != null) effectSource.mute = false;
    }
}