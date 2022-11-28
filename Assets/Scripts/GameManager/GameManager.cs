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
    public GameObject Levelmanager;
    private UIManager UI;
    public GameObject Player;
    private PlayerMovement PC;
    public TMP_Text valorText;
    public TMP_Text totalValorText;
    public TMP_Text valorGainedText;
    public TMP_Text valorMultiplerText;
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
    public int valorGained;
    public int previousValor;
    public int valorMultiplier;

    float baseSpeed;
    float baseTurretRotationSpeed;
    float baseRotationSpeed;
    float baseMaxFuel;
    int baseMaxHealth;
    int baseDamageValue;
    float baseReloadSpeed;
    int baseTotalValor;




    // Start is called before the first frame update
    void Start()
    {
        UImanager = GameObject.Find("GameManager/UIManager");
        UI = UImanager.GetComponent<UIManager>();
        upgrade = UpgradeScript.GetComponent<UpgradesScreen>();

        baseSpeed = speed;
        baseTurretRotationSpeed = turretRotationSpeed;
        baseRotationSpeed = rotationSpeed;
        baseMaxHealth = maxHealth;
        baseMaxFuel = maxFuel;
        baseReloadSpeed = reloadSpeed;
        baseDamageValue = damageValue;
        baseTotalValor = totalValor;
        valorMultiplier = 1;
        previousValor = 0;

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
                previousValor = totalValor;
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
                SetValor();

                break;
            default:
                break;
        }
    }

    public void ResetPlayerStats()
    {
        speed = baseSpeed;
        turretRotationSpeed = baseTurretRotationSpeed;
        rotationSpeed = baseRotationSpeed;
        maxHealth = baseMaxHealth;
        maxFuel = baseMaxFuel;
        reloadSpeed = baseReloadSpeed;
        damageValue = baseDamageValue;
        totalValor = baseTotalValor;
        valorMultiplier = 1;

        upgrade.fuelStep = 0;
        upgrade.speedStep = 0;
        upgrade.DamageStep = 0;
        upgrade.HealthStep = 0;
        upgrade.rotateStep = 0;
        upgrade.turretStep = 0;
        upgrade.reloadStep = 0;
        upgrade.valorStep = 0;

        if (!DoesFileExist())
        {
            File.Delete(Application.persistentDataPath + "/SaveGame.dat");
        }       
    }

    void SetValor() // Sets text at the game over screen
    {
        valorGained = totalValor - previousValor;        

        // set text
        totalValorText.text = "Total Valor: " + totalValor.ToString();
        valorGainedText.text = "Valor Gained: " + valorGained.ToString();
        valorMultiplerText.text = "Valor Multiplier: x" + valorMultiplier.ToString();
    }

    public bool DoesFileExist()
    {
        if (File.Exists(Application.persistentDataPath + "/SaveGame.dat"))
        {
            return true;
        }
        else return false;
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
        data.valorMultiplier = valorMultiplier;

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
            valorMultiplier = data.valorMultiplier;

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
        public int valorMultiplier;
    }
}
