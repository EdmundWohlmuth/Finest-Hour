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

    [Header("Price Steps")]
    public int fuelStep = 0;
    [SerializeField] int fuelIncrease = 15;
    public int speedStep = 0;
    [SerializeField] float speedStepIncrease = 0.25f;
    public int DamageStep = 0;
    [SerializeField] int DamageStepIncrease = 15;
    public int HealthStep = 0;
    [SerializeField] int healthStepIncrease = 15;

    [Header("Price Text Element")]
    public TMP_Text fuelPrice;
    public TMP_Text speedPrice;
    public TMP_Text damagePrice;
    public TMP_Text healthPrice;

    [Header("Step Text Element")]
    public TMP_Text fuelStepText;
    public TMP_Text speedStepText;
    public TMP_Text damageStepText;
    public TMP_Text healthStepText;


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

    }

    public void UpgradeTankRotationSpeed()
    {

    }

    public void UpgradeTankTrapProtection()
    {

    }

    public void UpgradeValorGain()
    {

    }

    void DisplayPrices()
    {
        fuelPrice.text = "Price: " + fuelPrices[fuelStep].ToString();
        fuelStepText.text = fuelStep + "/5";
        speedPrice.text = "Price: " + speedPrices[speedStep].ToString();
        speedStepText.text = speedStep + "/5";
        damagePrice.text = "Price: " + damagePrices[DamageStep].ToString();
        damageStepText.text = DamageStep + "/5";
        healthPrice.text = "Price: " + healthPrices[HealthStep].ToString();
        healthStepText.text = HealthStep + "/5";
    }
}
