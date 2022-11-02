using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class pips : MonoBehaviour
{
    public UpgradesScreen upgrades;

    int upgradeStep;
    List<Transform> Pips = new ();
    public enum UpgradeType
    {
        Fuel,
        Engine,
        Damage,
        Health,
        TurretRotation,
        ChasisRotation,
        ReloadSpeed,
        ValorModifier
    }
    public UpgradeType upgradeType;

    // Start is called before the first frame update
    void Start()
    {
        SetUpgradeType();

        foreach (Transform pip in transform) // when using transform like this it calls all direct children
        {                                    // Under the object it has been applied to
            Pips.Add(pip);
        }
        UpgradeStep();
    }

    // Update is called once per frame
    void Update()
    {
        UpgradeStep();
        SetUpgradeType(); // updates the pips
    }

    void UpgradeStep()
    {
        //Debug.Log("Step: " + upgradeStep);
        if (upgradeStep > 0)
        {
            for (int i = 0; i < upgradeStep; i++)
            {
                Pips[i].gameObject.GetComponent<Image>().color = Color.yellow;
            }
        }
       // Debug.Log("Ran Upgradestep");
    }

    void SetUpgradeType()
    {
        switch (upgradeType)
        {
            case UpgradeType.Fuel:
                upgradeStep = upgrades.fuelStep;
                break;
            case UpgradeType.Engine:
                upgradeStep = upgrades.speedStep;
                break;
            case UpgradeType.Damage:
                upgradeStep = upgrades.DamageStep;
                break;
            case UpgradeType.Health:
                upgradeStep = upgrades.HealthStep;
                break;
            case UpgradeType.TurretRotation:
                upgradeStep = upgrades.turretStep;
                break;
            case UpgradeType.ChasisRotation:
                upgradeStep = upgrades.rotateStep;
                break;
            case UpgradeType.ReloadSpeed:
                upgradeStep = upgrades.reloadStep;
                break;
            case UpgradeType.ValorModifier:
                upgradeStep = upgrades.valorStep;
                break;
        }
    }
}
