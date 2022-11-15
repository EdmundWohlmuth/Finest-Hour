using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesScreen : MonoBehaviour
{
    [Header("Refrences")]
    public GameObject gameManager;
    private GameManager GM;

    [Header("Price Lists")]
    public List<int> fuelPrices = new List<int>(6);    
    public List<int> speedPrices = new List<int>(5);
    public List<int> damagePrices = new List<int>(5);
    public List<int> healthPrices = new List<int>(5);
    public List<int> turretPrices = new List<int>(5);
    public List<int> rotationPrices = new List<int>(5);
    public List<int> ReloadPrices = new List<int>(5);
    public List<int> valorPrices = new List<int>(2);

    [Header("Price Steps")]
    public int fuelStep = 0;
    [SerializeField] int fuelIncrease = 20;
    public int speedStep = 0;
    [SerializeField] float speedStepIncrease = 0.25f;
    public int DamageStep = 0;
    [SerializeField] int DamageStepIncrease = 2;
    public int HealthStep = 0;
    [SerializeField] int healthStepIncrease = 5;
    public int turretStep = 0;
    [SerializeField] float turretStepIncrease = 2f;
    public int rotateStep = 0;
    [SerializeField] float rotationStepIncrease = 15f;
    public int reloadStep = 0;
    [SerializeField] float reloadStepIncrease = 0.3f;
    public int valorStep = 0;
    [SerializeField] int valorStepIncrease = 1;

    [Header("Price Text Element")]
    public TMP_Text fuelPrice;
    public TMP_Text speedPrice;
    public TMP_Text damagePrice;
    public TMP_Text healthPrice;
    public TMP_Text turretPrice;
    public TMP_Text rotatePrice;
    public TMP_Text reloadPrice;
    public TMP_Text valorPrice;

    [Header("Buttons")]
    public Button fuelButton;
    public Button engineButton;
    public Button damageButton;
    public Button armorButton;
    public Button turretButton;
    public Button chasisButton;
    public Button reloadButton;
    public Button valorButton;


    private void Start()
    {
        // THIS ENTIRE .CS FILE NEEDS TO BE REWORKED, LOTS OF REPEAT CODE - Edmund: 22-11-15
        GM = gameManager.GetComponent<GameManager>();       
    }

    private void Update()
    {
        DisplayPrices();
        DisableButtonCheck();
    }

    public void UpgradeFuel()
    {
        if (GM.totalValor >= fuelPrices[fuelStep])
        {
            GM.maxFuel += fuelIncrease;
            GM.totalValor -= fuelPrices[fuelStep];
            fuelStep++;
        }
    }

    public void UpgradeSpeed()
    {
        if (GM.totalValor >= speedPrices[speedStep])
        {
            GM.speed += speedStepIncrease;
            GM.totalValor -= speedPrices[speedStep];
            speedStep++;
        }
    }

    public void UpgradeDamage()
    {
        if (GM.totalValor >= damagePrices[DamageStep])
        {
            GM.damageValue += DamageStepIncrease;
            GM.totalValor -= damagePrices[DamageStep];
            DamageStep++;
        }
    }

    public void UpgradeHealth()
    {
        if (GM.totalValor >= healthPrices[HealthStep])
        {
            GM.maxHealth += healthStepIncrease;
            GM.totalValor -= healthPrices[HealthStep];
            HealthStep++;
        }
    }

    public void UpgradeTurretSpeed()
    {
        if (GM.totalValor >= turretPrices[turretStep])
        {
            GM.turretRotationSpeed += turretStepIncrease;
            GM.totalValor -= turretPrices[turretStep];
            turretStep++;
        }
    }

    public void UpgradeTankRotationSpeed()
    {
        if (GM.totalValor >= rotationPrices[rotateStep])
        {
            GM.rotationSpeed += rotationStepIncrease;
            GM.totalValor -= rotationPrices[rotateStep];
            rotateStep++;
        }
    }

    public void UpgradeReloadSpeed()
    {
        if (GM.totalValor >= ReloadPrices[reloadStep])
        {
            GM.reloadSpeed -= reloadStepIncrease;
            GM.totalValor -= ReloadPrices[reloadStep];
            reloadStep++;
        }
    }

    public void UpgradeValorGain()
    {
        if (GM.totalValor >= valorPrices[valorStep])
        {
            GM.valorMultiplier += valorStepIncrease;
            GM.totalValor -= valorPrices[valorStep];
            valorStep++;
        }
    }

    void DisplayPrices()
    {
        fuelPrice.text = "Price: " + fuelPrices[fuelStep].ToString();
        speedPrice.text = "Price: " + speedPrices[speedStep].ToString();
        damagePrice.text = "Price: " + damagePrices[DamageStep].ToString();
        healthPrice.text = "Price: " + healthPrices[HealthStep].ToString();
        turretPrice.text = "Price " + turretPrices[turretStep].ToString();
        rotatePrice.text = "Price: " + rotationPrices[rotateStep].ToString();
        reloadPrice.text = "Price: " + ReloadPrices[reloadStep].ToString();
        valorPrice.text = valorPrices[valorStep].ToString();
    }

    void DisableButtonCheck()
    {
        if (fuelStep >= 5)
        {
            fuelButton.interactable = false;
        }
        if (speedStep >= 5)
        {
            engineButton.interactable = false;
        }
        if (DamageStep >= 5)
        {
            damageButton.interactable = false;
        }
        if (HealthStep >= 5)
        {
            armorButton.interactable = false;
        }
        if (turretStepIncrease >= 5)
        {
            turretButton.interactable = false;
        }
        if (rotateStep >= 5)
        {
            chasisButton.interactable = false;
        }
        if (reloadStep >= 5)
        {
            reloadButton.interactable = false;
        }
        if (valorStep >= 2)
        {
            valorButton.interactable = false;
        }
    }
}
