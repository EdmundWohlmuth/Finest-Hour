using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradesScreen : MonoBehaviour
{
    [Header("Refrences")]
    public GameObject gameManager;
    private GameManager GM;

    [Header("Price Lists")]
    public List<int> fuelPrices = new List<int>(5);    
    public List<int> speedPrices = new List<int>(5);
    public List<int> damagePrices = new List<int>(5);
    public List<int> healthPrices = new List<int>(5);
    public List<int> turretPrices = new List<int>(5);
    public List<int> rotationPrices = new List<int>(5);
    public List<int> ReloadPrices = new List<int>(5);
    public List<int> valorPrices = new List<int>(2);

    [Header("Price Steps")]
    public int fuelStep = 0;
    [SerializeField] int fuelIncrease = 15;
    public int speedStep = 0;
    [SerializeField] float speedStepIncrease = 0.25f;
    public int DamageStep = 0;
    [SerializeField] int DamageStepIncrease = 2;
    public int HealthStep = 0;
    [SerializeField] int healthStepIncrease = 5;
    public int turretStep = 0;
    [SerializeField] float turretStepIncrease = 2f;
    public int rotateStep = 0;
    [SerializeField] float rotationStepIncrease = 10f;
    public int reloadStep = 0;
    [SerializeField] float reloadStepIncrease = -0.3f;
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

    [Header("Step Text Element")]
    public TMP_Text fuelStepText;
    public TMP_Text speedStepText;
    public TMP_Text damageStepText;
    public TMP_Text healthStepText;
    public TMP_Text turretStepText;
    public TMP_Text rotateStepText;
    public TMP_Text relaodStepText;
    public TMP_Text valorStepText;


    private void Start()
    {
        GM = gameManager.GetComponent<GameManager>();
    }

    private void Update()
    {
        DisplayPrices();
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
            GM.reloadSpeed += ReloadPrices[reloadStep];
            GM.totalValor -= ReloadPrices[reloadStep];
            reloadStep++;
        }
    }

    public void UpgradeValorGain()
    {
        if (GM.totalValor >= valorPrices[valorStep])
        {

        }
    }

    void DisplayPrices()
    {
        // WILL CHANGE ...StepText to a bar value and put it behind another element to make it look nicer
        fuelPrice.text = "Price: " + fuelPrices[fuelStep].ToString();
        fuelStepText.text = fuelStep + "/5";
        speedPrice.text = "Price: " + speedPrices[speedStep].ToString();
        speedStepText.text = speedStep + "/5";
        damagePrice.text = "Price: " + damagePrices[DamageStep].ToString();
        damageStepText.text = DamageStep + "/5";
        healthPrice.text = "Price: " + healthPrices[HealthStep].ToString();
        healthStepText.text = HealthStep + "/5";
        turretPrice.text = "Price " + turretPrices[turretStep].ToString();
        turretStepText.text = turretStep + "/5";
        rotatePrice.text = "Price: " + rotationPrices[rotateStep].ToString();
        rotateStepText.text = rotateStep + "/5";
        reloadPrice.text = "Price: " + ReloadPrices[reloadStep].ToString();
        relaodStepText.text = reloadStep + "/5";
        valorPrice.text = valorPrices[valorStep].ToString();
        valorStepText.text = valorStep + "/5";
    }
}
