using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Music")]
    public AudioSource musicSource;
    public AudioClip backgroundMusic;

    [Header("SFX")]
    public AudioSource sfxSource;
    public AudioClip buttonClickSound;
    public AudioClip bubbleBounceSound;
    public AudioClip bubblePopSound;
    public AudioClip walkSound;

    private bool isMuted = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    void Start()
    {
        if (backgroundMusic != null)
        {
            musicSource.clip = backgroundMusic;
            musicSource.loop = true;
            musicSource.Play();
        }
    }

    public void PlayButtonClick()
    {
        sfxSource.PlayOneShot(buttonClickSound);
    }

    public void PlayBubbleBounce()
    {
        sfxSource.PlayOneShot(bubbleBounceSound);
    }

    public void PlayBubblePop()
    {
        sfxSource.PlayOneShot(bubblePopSound);
    }

    public void ToggleMute()
    {
        isMuted = !isMuted;
        musicSource.mute = isMuted;
    }

    public bool IsMuted()
    {
        return isMuted;
    }

    public void PlayWalk()
    {
        if (walkSound == null) return;
        if (sfxSource.isPlaying) return;
        sfxSource.PlayOneShot(walkSound);
    }

    public void SetMusicVolume(float volume)
    {
        musicSource.volume = volume;
    }

    public float GetMusicVolume()
    {
        return musicSource.volume;
    }
}