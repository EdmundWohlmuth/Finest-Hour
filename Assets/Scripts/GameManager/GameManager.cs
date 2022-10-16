using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [Header("Refrences")]
    public GameObject UImanager;
    private UIManager UI;
    public GameObject Player;
    private PlayerMovement PC;
    public TMP_Text valorText;

    [Header("PlayerStats")]
    public float speed;
    public float turretRotationSpeed;
    public float rotationSpeed;
    public float maxFuel;
    public int maxHealth;
    public int damageValue;
    public int totalValor;


    // Start is called before the first frame update
    void Start()
    {
        UImanager = GameObject.Find("GameManager/UIManager");
        UI = UImanager.GetComponent<UIManager>();
    }

    // Update is called once per frame
    void Update()
    {
        MenuState();
    }

    void MenuState()
    {
        switch (UI.currentState)
        {
            case UIManager.CurrentScreen._MainMenu:

                Time.timeScale = 1;
                UI.MainMenuState();

                break;
            case UIManager.CurrentScreen._Upgrade:

                Time.timeScale = 1;
                UI.UpgradeState();
                UpgradesScreen();

                break;
            case UIManager.CurrentScreen._GamePlay:

                Time.timeScale = 1;
                UI.GamePlayState();

                break;
            case UIManager.CurrentScreen._Pause:

                Time.timeScale = 0;

                break;
            case UIManager.CurrentScreen._Win:

                Time.timeScale = 0;

                break;
            case UIManager.CurrentScreen._Loose:

                Time.timeScale = 0;
                UI.LooseState();
                PullPlayerValues();

                break;
            default:
                break;
        }
    }

    void PullPlayerValues()
    {
        speed = PC.movementSpeed;
        turretRotationSpeed = PC.turretRotationSpeed;
        rotationSpeed = PC.chasisRotationSpeed;
        maxFuel = PC.maxFuel;
        maxHealth = PC.maxHealth;
        damageValue = PC.damageValue;
        totalValor = PC.valorPoints;
    }

    public void SaveGame()
    {
        // save to file


    }

    public void LoadGame()
    {
        // load from file


    }

    void UpgradesScreen()
    {
        valorText.text = "Total Valor: " + totalValor.ToString();
    }
}
