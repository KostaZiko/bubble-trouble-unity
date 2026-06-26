using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    public AudioClip backgroundMusic;

    [Header("SFX")]
    public AudioClip buttonClickSound;
    public AudioClip bubbleBounceSound;
    public AudioClip bubblePopSound;
    public AudioClip walkSound;


    private AudioSource musicSource;
    private AudioSource sfxSource;

    private bool isMuted = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SetupAudioSources(); 
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void SetupAudioSources()
    {

        musicSource = gameObject.AddComponent<AudioSource>();
        musicSource.loop = true;
        musicSource.playOnAwake = false;


        sfxSource = gameObject.AddComponent<AudioSource>();
        sfxSource.playOnAwake = false;
    }

    void Start()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.Play();
        }
    }

    public void PlayButtonClick()
    {
        if (sfxSource == null || buttonClickSound == null) return;
        sfxSource.PlayOneShot(buttonClickSound);
    }

    public void PlayBubbleBounce()
    {
        if (sfxSource == null || bubbleBounceSound == null) return;
        sfxSource.PlayOneShot(bubbleBounceSound);
    }

    public void PlayBubblePop()
    {
        if (sfxSource == null || bubblePopSound == null) return;
        sfxSource.PlayOneShot(bubblePopSound);
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        musicSource.mute = isMuted;
        sfxSource.mute = isMuted;
    }

    public bool IsMuted()
    {
        return isMuted;
    }

    public void PlayWalk()
    {
        if (sfxSource == null || walkSound == null) return;
        if (sfxSource.isPlaying) return;
        sfxSource.PlayOneShot(walkSound);
    }

    public void SetMusicVolume(float volume)
    {
        if (musicSource == null) return;
        musicSource.volume = volume;
    }

    public float GetMusicVolume()
    {
        if (musicSource == null) return 0f;
        return musicSource.volume;
    }
}