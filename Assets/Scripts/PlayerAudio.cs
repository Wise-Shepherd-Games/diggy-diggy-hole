using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    public AudioSource audioSource;
    public List<AudioClip> DashSounds = new List<AudioClip>();
    public List<AudioClip> OuchClips = new List<AudioClip>();

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.LeftShift))
            PlayDash();
    }

    private void PlayDash()
    {
        audioSource.Stop();
        audioSource.volume = 1;
        audioSource.PlayOneShot(GetRandomAudioClip(this.DashSounds));
    }

    private void PlayOuch()
    {
        audioSource.Stop();
        audioSource.volume = 0.8f;
        audioSource.PlayOneShot(GetRandomAudioClip(this.OuchClips));
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Trap")
            PlayOuch();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Trap")
            PlayOuch();
    }

    private AudioClip GetRandomAudioClip(List<AudioClip> audioClips) => audioClips[Random.Range(0, audioClips.Count)];
}
