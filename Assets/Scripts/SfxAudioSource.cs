using UnityEngine;

public class SfxAudioSource : SingletonMonoBehaviour<SfxAudioSource>
{
    private AudioSource audioSource;

    protected override void Awake()
    {
        base.Awake();

        audioSource = GetComponent<AudioSource>();
    }

    public void PlaySfx(AudioClip audioClip)
    {
        audioSource.PlayOneShot(audioClip);
    }
}
