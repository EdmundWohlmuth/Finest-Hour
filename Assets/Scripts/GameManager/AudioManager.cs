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
    public AudioClip playerFire;
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
        if (player == null && uIManager.currentState == UIManager.CurrentScreen._GamePlay)
        {
            player = GameObject.Find("Player");
            playerTank = player.GetComponent<AudioSource>();

            playerBarrel = GameObject.Find("Turret");
            playerTurret = playerBarrel.GetComponent<AudioSource>();
        }
        else if (player != null)
        {
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
    }

    public void PlayButtonNoise()
    {
        buttonPress.PlayOneShot(buttonDown);
    }
}
