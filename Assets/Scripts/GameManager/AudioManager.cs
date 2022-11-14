using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Gamemanager objects:")]
    public UIManager uIManager;

    [Header("Gameplay objects:")]
    public GameObject player;
    public GameObject playerBarrel;   

    [Header("Audio Clips:")]
    public AudioClip buttonDown;
    public AudioClip gunShotL;
    public AudioClip gunShotH;
    public AudioClip tankMove;
    public AudioClip playerTankLowFuel;
    public AudioClip explosion;

    [Header("Audio Sources:")]
    public AudioSource buttonPress;
    public AudioSource playerTurret;
    public AudioSource playerTank;

    public void PlayButtonSound()
    {
        buttonPress.PlayOneShot(buttonDown);
    }

    public void PlayGunSoundL(AudioSource source)
    {
        source.PlayOneShot(gunShotL);
    }

    public void PlayGunSoundH(AudioSource source)
    {
        source.PlayOneShot(gunShotH);
    }

    public void PlayExplosion(AudioSource source)
    {
        source.PlayOneShot(explosion);
    }

    public void PlayEngineSound(AudioSource source)
    {
        // might make sense to run this on the player itself
    }
}