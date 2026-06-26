using UnityEngine;
using TMPro;

public class MuteButton : MonoBehaviour
{
    public TMP_Text buttonText;

    public void OnMutePressed()
    {
        AudioManager.Instance?.ToggleMute();
        UpdateIcon();
    }

    void UpdateIcon()
    {
        if (buttonText == null) return;
        buttonText.text = AudioManager.Instance.IsMuted() ? "🔇" : "🔊";
    }
}