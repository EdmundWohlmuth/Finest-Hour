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
    public AudioClip playerTankMove;
    public AudioClip playerTankLowFuel;

    [Header("Audio Sources:")]
    public AudioSource buttonPress;
    public AudioSource playerTurret;
    public AudioSource playerTank;

    void Start()
    {
       
    }

    void Update()
    {
        CheckPlayer();
    }

    void CheckPlayer()
    {
        player = GameObject.Find("Player");
        playerTank = player.GetComponent<AudioSource>();

        playerBarrel = GameObject.Find("Turret");
        playerTurret = playerBarrel.GetComponent<AudioSource>();

        PlayerMovement playerScript = player.GetComponent<PlayerMovement>();
        if (playerScript.currentFuel < (playerScript.maxFuel / 3))
        {
            playerTank.clip = playerTankLowFuel;
        }
        else
        {
            playerTank.clip = playerTankMove;
        }
    }

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
}
