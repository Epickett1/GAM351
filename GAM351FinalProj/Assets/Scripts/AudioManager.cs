using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {
    [Header("----------- Audio Source -----------")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource ambienceSource;
    [SerializeField] AudioSource SFXSource;

[Header("----------- Audio Clip -----------")]
    public AudioClip backgroundAmbience;
    public AudioClip fightingMusic;
    public AudioClip lightLaserSound;
    public AudioClip heavyLaserSound;
    public AudioClip powerupSound;

    private void Start() {
        musicSource.clip = backgroundAmbience;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip) {
        SFXSource.PlayOneShot(clip);
    }

    public void PlayMusic(AudioClip clip) {
        musicSource.PlayOneShot(clip);
    }

    public void PlayAmbience(AudioClip clip) {
        ambienceSource.PlayOneShot(clip);
    }
}
