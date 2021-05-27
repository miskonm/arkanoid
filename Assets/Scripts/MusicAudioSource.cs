using System;
using UnityEngine;

public class MusicAudioSource : SingletonMonoBehaviour<MusicAudioSource>
{
    [SerializeField] private AudioClip[] musics;

    private AudioSource audioSource;

    public void Play(AudioClip clip)
    {
        audioSource.clip = clip;
        audioSource.Play();
    }
}
