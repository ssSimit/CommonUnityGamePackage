using UnityEngine;
using System.Collections.Generic;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance;

    private AudioSource audioSource;
    private AudioSource continuousAudioSource;
    [SerializeField] private AudioClip bgmClip;
    [SerializeField] private AudioClip gameBgmClip;
    [SerializeField] private AudioClip continuousClip;

    [SerializeField] private List<AudioClip> audioClips = new List<AudioClip>();

    public bool isMuted = false;

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
        }


        audioSource = gameObject.AddComponent<AudioSource>();
        continuousAudioSource = gameObject.AddComponent<AudioSource>();
        SetContinuousAudio();
    }

    public void PlayAudio(string clipName)
    {
        foreach (AudioClip clip in audioClips)
        {
            if (clip != null && clip.name == clipName)
            {
                audioSource.PlayOneShot(clip);
                return;
            }
        }
        Debug.LogWarning($"Audio clip '{clipName}' not found in MusicManager!");
    }

    void SetContinuousAudio()
    {
        if (continuousClip != null)
        {
            continuousAudioSource.clip = continuousClip;
            continuousAudioSource.loop = true;
            continuousAudioSource.volume = 0.5f;
            continuousAudioSource.playOnAwake = false;
        }
    }

    public void PlayBGM()
    {
        if (bgmClip != null)
        {
            audioSource.clip = bgmClip;
            audioSource.loop = true;
            audioSource.volume = 0.5f;
            audioSource.Play();
        }
    }

    public void PlayGameBGM()
    {
        if (gameBgmClip != null)
        {
            audioSource.clip = gameBgmClip;
            audioSource.loop = true;
            audioSource.volume = 0.4f;
            audioSource.Play();
        }
    }


    public void StopBGM()
    {
        audioSource.Stop();
    }

    public void MuteUnmuteAudio()
    {
        isMuted = !isMuted;
        audioSource.mute = isMuted;
        continuousAudioSource.mute = isMuted;
    }

    public void PauseMute(bool paused)
    {
        if (paused)
        {
            audioSource.mute = true;
            continuousAudioSource.mute = true;
        }
        else
        {
            audioSource.mute = isMuted;
            continuousAudioSource.mute = isMuted;
        }
    }

}