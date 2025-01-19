using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Clips")]
    public Audio[] audios;

    private static AudioManager instance;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Audio a in audios)
        {
            a.source = gameObject.AddComponent<AudioSource>();
            a.source.clip = a.audioFile;
            a.source.volume = a.volume;
            a.source.pitch = a.pitch;
            a.source.loop = a.loop;
        }
    }

    public void Play(string name)
    {
        Audio a = Array.Find(audios, audios => audios.name == name);

        if (a == null)
        {
            Debug.LogWarning($"Audio clip '{name}' no encontrado.");
            return;
        }

        a.source.Play();
    }

    public void Stop(string name)
    {
        Audio a = Array.Find(audios, audios => audios.name == name);

        if (a == null)
        {
            Debug.LogWarning($"Audio clip '{name}' no encontrado.");
            return;
        }

        a.source.Stop();
    }

    public void SetVolume(string name, float volume)
    {
        Audio a = Array.Find(audios, audios => audios.name == name);

        if (a == null)
        {
            Debug.LogWarning($"Audio clip '{name}' no encontrado.");
            return;
        }

        a.source.volume = Mathf.Clamp01(volume);
    }

    public void SetGlobalVolume(float volume)
    {
        AudioListener.volume = Mathf.Clamp01(volume);
    }
}
