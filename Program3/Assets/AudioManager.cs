using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("--------- Audio Source ---------")]
    [SerializeField] AudioSource ambienceSource;
    [SerializeField] AudioSource foleySource;
    [SerializeField] AudioSource tauntsSource;

    [Header("--------- Audio Clip ---------")]
    public AudioClip suspenseAmbience;
    public AudioClip fightAmbience;
    public AudioClip defaultAmbience;
    public AudioClip footsteps;
    public AudioClip gunshot;
    public AudioClip explosion;
    public AudioClip windAmbience;
    public AudioClip death;
    public AudioClip taunt1;
    public AudioClip taunt2;
    public AudioClip taunt3;

    void Start() {
        ambienceSource.clip = defaultAmbience;
        ambienceSource.Play();
    }

    public void PlayFoley(AudioClip clip) {
        foleySource.PlayOneShot(clip);

    }

    public void PlayTaunt(AudioClip clip) {
        tauntsSource.PlayOneShot(clip);
    }

    public void PlayAmbience(AudioClip clip) {
        ambienceSource.PlayOneShot(clip);
    }
}
