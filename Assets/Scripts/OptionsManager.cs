using UnityEngine;
using UnityEngine.UI;

public class OptionsManager : MonoBehaviour
{
    public Slider musicSlider;

    void Start()
    {
        if (AudioManager.Instance != null)
            musicSlider.value = AudioManager.Instance.GetMusicVolume();
    }

    public void OnVolumeChanged()
    {
        AudioManager.Instance?.SetMusicVolume(musicSlider.value);
    }
}