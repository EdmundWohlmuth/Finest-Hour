using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class GameManager : MonoBehaviour
{
    [Header("Refrences")]
    public GameObject UImanager;
    private UIManager UI;
    public GameObject Player;
    private PlayerMovement PC;
    public TMP_Text valorText;
    public TMP_Text totalValorText;
    public GameObject UpgradeScript;
    public UpgradesScreen upgrade;
    public Button continueButton;

    [Header("PlayerStats")]
    public float speed;
    public float turretRotationSpeed;
    public float rotationSpeed;
    public float maxFuel;
    public int maxHealth;
    public int damageValue;
    public float reloadSpeed;
    public int totalValor;


    // Start is called before the first frame update
    void Start()
    {
        UImanager = GameObject.Find("GameManager/UIManager");
        UI = UImanager.GetComponent<UIManager>();

        UpgradeScript = GameObject.Find("GameManager/UIManager/UpgradeScreen");
        upgrade = UpgradeScript.GetComponent<UpgradesScreen>();
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

                if (File.Exists(Application.persistentDataPath + "/SaveGame.dat"))
                {
                    continueButton.interactable = true;
                }
                else continueButton.interactable = false;


                break;
            case UIManager.CurrentScreen._Upgrade:

                Time.timeScale = 1;
                UI.UpgradeState();
                UpgradesScreen();

                break;
            case UIManager.CurrentScreen._GamePlay:

                Time.timeScale = 1;
                UI.GamePlayState();
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    UI.PauseState();
                }

                break;
            case UIManager.CurrentScreen._Pause:

                Time.timeScale = 0;
                if (Input.GetKeyDown(KeyCode.Escape))
                {
                    UI.GamePlayState();
                }

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
        speed = PC.movementSpeed; // Do I need all this? Shouldn't I just be checking for valor?
        turretRotationSpeed = PC.turretRotationSpeed;
        rotationSpeed = PC.chasisRotationSpeed;
        maxFuel = PC.maxFuel;
        maxHealth = PC.maxHealth;
        damageValue = PC.damageValue;
        totalValor = PC.valorPoints;
        rotationSpeed = PC.chasisRotationSpeed;
        turretRotationSpeed = PC.turretRotationSpeed;
        reloadSpeed = PC.reloadTime;

        // set text
        totalValorText.text = "Total Valor: " + totalValor.ToString();
    }

    void showGainedValor()
    {

    }

    public void SaveGame()
    {
        // save to file
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/SaveGame.dat");

        SavedData data = new SavedData();
        // player Data
        data.speed = speed;
        data.turretRotationSpeed = turretRotationSpeed;
        data.rotationSpeed = rotationSpeed;
        data.maxFuel = maxFuel;
        data.maxHealth = maxHealth;
        data.damageValue = damageValue;
        data.totalValor = totalValor;

        // Upgrade Data
        data.fuelStep = upgrade.fuelStep;
        data.speedStep = upgrade.speedStep;
        data.DamageStep = upgrade.DamageStep;
        data.HealthStep = upgrade.HealthStep;
        data.chasisRotationStep = upgrade.rotateStep;
        data.turretRotationStep = upgrade.turretStep;
        data.reloadStep = upgrade.reloadStep;
        data.valorStep = upgrade.valorStep;
        

        bf.Serialize(file, data);
        file.Close();
    }

    public void LoadGame()
    {
        // load from file
        if (File.Exists(Application.persistentDataPath + "/SaveGame.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/SaveGame.dat", FileMode.Open);

            SavedData data = (SavedData)bf.Deserialize(file);
            file.Close();
            // player Data
            speed = data.speed;
            turretRotationSpeed = data.turretRotationSpeed;
            rotationSpeed = data.rotationSpeed;
            maxFuel = data.maxFuel;
            maxHealth = data.maxHealth;
            damageValue = data.damageValue;
            totalValor = data.totalValor;

            // Upgrade Data
            upgrade.fuelStep = data.fuelStep;
            upgrade.speedStep = data.speedStep;
            upgrade.DamageStep = data.DamageStep;
            upgrade.HealthStep = data.HealthStep;
            upgrade.rotateStep = data.chasisRotationStep;
            upgrade.turretStep = data.turretRotationStep;
            upgrade.reloadStep = data.reloadStep;
            upgrade.valorStep = data.valorStep;

        }

    }

    void UpgradesScreen()
    {
        valorText.text = "Total Valor: " + totalValor.ToString();
    }

    [Serializable]
    class SavedData
    {
        // player Data
        public float speed;
        public float turretRotationSpeed;
        public float rotationSpeed;
        public float maxFuel;
        public int maxHealth;
        public int damageValue;
        public int totalValor;

        // Upgrade Data
        public int fuelStep;
        public int speedStep;
        public int DamageStep;
        public int HealthStep;
        public int turretRotationStep;
        public int chasisRotationStep;
        public int reloadStep;
        public int valorStep;
    }
}
