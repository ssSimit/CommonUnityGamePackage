using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] Image soundImg;
    [SerializeField] Sprite soundOnSprite;
    [SerializeField] Sprite soundOffSprite;

    [SerializeField] private Button soundBtn;

    void Start()
    {
        UpdateSoundIcon();
        soundBtn.onClick.AddListener(MuteUnMute);
    }
    public void MuteUnMute()
    {
        MusicManager.Instance.MuteUnmuteAudio();
        UpdateSoundIcon();
    }

    void UpdateSoundIcon()
    {
        if (soundImg == null || soundOnSprite == null || soundOffSprite == null)
        {
            Debug.LogWarning("SoundController: One or more references are missing. Please assign them in the inspector.");
            return;
        }
        if (MusicManager.Instance.isMuted)
        {
            soundImg.sprite = soundOffSprite;
        }
        else
        {
            soundImg.sprite = soundOnSprite;
        }
    }
}
