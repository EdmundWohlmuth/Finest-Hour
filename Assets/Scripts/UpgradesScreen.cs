using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UpgradesScreen : MonoBehaviour
{
    [Header("Refrences")]
    public GameObject gameManager;
    private GameManager GM;
    public AudioManager AM;
    public AudioSource source;

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

    [Header("Buttons")]
    public Button fuelButton;
    public Button engineButton;
    public Button damageButton;
    public Button armorButton;
    public Button turretButton;
    public Button chasisButton;
    public Button reloadButton;
    public Button valorButton;

    // declare button on button press
    Button button;


    private void Start()
    {
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
            button = fuelButton;

            GM.maxFuel += fuelIncrease;
            GM.totalValor -= fuelPrices[fuelStep];
            fuelStep++;

            ButtonEffects();
        }
    }

    public void UpgradeSpeed()
    {
        if (GM.totalValor >= speedPrices[speedStep])
        {
            button = engineButton;

            GM.speed += speedStepIncrease;
            GM.totalValor -= speedPrices[speedStep];
            speedStep++;

            ButtonEffects();
        }
    }

    public void UpgradeDamage()
    {
        if (GM.totalValor >= damagePrices[DamageStep])
        {
            button = damageButton;

            GM.damageValue += DamageStepIncrease;
            GM.totalValor -= damagePrices[DamageStep];
            DamageStep++;

            ButtonEffects();
        }
    }

    public void UpgradeHealth()
    {
        if (GM.totalValor >= healthPrices[HealthStep])
        {
            button = armorButton;

            GM.maxHealth += healthStepIncrease;
            GM.totalValor -= healthPrices[HealthStep];
            HealthStep++;

            ButtonEffects();
        }
    }

    public void UpgradeTurretSpeed()
    {
        if (GM.totalValor >= turretPrices[turretStep])
        {
            button = turretButton;

            GM.turretRotationSpeed += turretStepIncrease;
            GM.totalValor -= turretPrices[turretStep];
            turretStep++;

            ButtonEffects();
        }
    }

    public void UpgradeTankRotationSpeed()
    {
        if (GM.totalValor >= rotationPrices[rotateStep])
        {
            button = chasisButton;

            GM.rotationSpeed += rotationStepIncrease;
            GM.totalValor -= rotationPrices[rotateStep];
            rotateStep++;

            ButtonEffects();
        }
    }

    public void UpgradeReloadSpeed()
    {
        if (GM.totalValor >= ReloadPrices[reloadStep])
        {
            button = reloadButton;

            GM.reloadSpeed += reloadStepIncrease;
            GM.totalValor -= ReloadPrices[reloadStep];
            reloadStep++;

            ButtonEffects();
        }
    }

    public void UpgradeValorGain()
    {
        if (GM.totalValor >= valorPrices[valorStep])
        {
            button = valorButton;

            GM.valorMultiplier += valorStepIncrease;
            GM.totalValor -= valorPrices[valorStep];
            valorStep++;

            ButtonEffects();
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
        valorPrice.text = "Price: " + valorPrices[valorStep].ToString();
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

    void ButtonEffects()
    {
        AM.PlayButtonSound(source);

        int id = LeanTween.scale(button.gameObject, new Vector3(.85f, .85f, .85f), .1f).id;

        LTDescr d = LeanTween.descr(id);

        if (d != null)
        {
            d.setOnComplete(ButtonEffects2);
        }
    }

    void ButtonEffects2()
    {
        LeanTween.scale(button.gameObject, new Vector3(1, 1, 1), .1f);
    }
}
