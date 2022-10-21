using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    [Header("UI / GM Managerment")]
    // ui init
    public GameObject gameManager;
    private GameManager GM;
    public GameObject uIManager;
    private UIManager UI;
    public GameObject valorMenu;

    [Header("Character Stats")]
    // stats init
    public int valorPoints;
    public TMP_Text valor;
    public int maxHealth;
    public int damageValue;
    public float movementSpeed = 0.5f;
    public float chasisRotationSpeed = 25;

    [Header("Fuel Systems")]
    // Fuel init
    public float maxFuel;
    public float currentFuel;
    public GameObject gas;
    public Slider gasMeter;

    [Header("Turret Control")]
    // aim init
    public Camera mainCamera;
    public GameObject crossHair;
    public float turretRotationSpeed = 10f;
    public GameObject turret;


    [Header("Shooting")]
    public GameObject bullet;
    public float reloadTime = 1;
    public GameObject muzzle;
    bool canShoot = true;
    public GameObject tankColliders;
    float currentDelay = 0;

    // Start is called before the first frame update
    void Start()
    {
        // Get GameManager
        gameManager = GameObject.Find("GameManager");
        GM = gameManager.GetComponent<GameManager>();
        // Get UIManager
        uIManager = GameObject.Find("GameManager/UIManager");
        UI = uIManager.GetComponent<UIManager>();

        // Get gas slider
        gas = GameObject.Find("GameManager/UIManager/Gameplay/GasMeter");
        gasMeter = gas.GetComponent<Slider>();
        gasMeter.maxValue = GM.maxFuel;
        gasMeter.value = GM.maxFuel;

        //valor
        valorMenu = GameObject.Find("GameManager/UIManager/Gameplay/ValorText (TMP)");
        valor = valorMenu.GetComponent<TMP_Text>();

        // set player values
        maxHealth = GM.maxHealth;
        damageValue = GM.damageValue;
        currentFuel = GM.maxFuel;
        movementSpeed = GM.speed;
        chasisRotationSpeed = GM.rotationSpeed;
        turretRotationSpeed = GM.turretRotationSpeed;
        valorPoints = GM.totalValor;

    }

    // Update is called once per frame
    void Update()
    {
        TankMovement();
        Aim();
        TurretRotate();
        ShootCheck();
        SpendFuel();
        CheckValor();
    }

    // ------------------------ Tank Chasis Movement ------------------------- \\
    void TankMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * movementSpeed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            float rotation = -1f * chasisRotationSpeed;
            transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            float rotation = 1f * chasisRotationSpeed;
            transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        }

        // moves turret with tank
        turret.transform.position = transform.position;
    }

    // -------------------------------- FUEL ------------------------ \\
    void SpendFuel()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            currentFuel = currentFuel -= Time.deltaTime;

            if (currentFuel <= 0)
            {
                currentFuel = 0; // "out of gas UI"
                UI.LooseState();
            }
            else
            {
                gasMeter.value = currentFuel;
            }           
        } // if fuel is low add blibking, engine sputtering sounds etc.
    }

    // ------------------------------ Turret Movement ----------------------------- \\
    void Aim()
    {
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        crossHair.transform.position = mousePosition;
    }
    void TurretRotate()
    {
        Vector2 relativePos = crossHair.transform.position - turret.transform.position;
        float angle = Mathf.Atan2(relativePos.x, relativePos.y) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        Quaternion current = turret.transform.localRotation;

        turret.transform.localRotation = Quaternion.Slerp(current, rotation, turretRotationSpeed * Time.deltaTime);
    }

    // --------------------------------- Shooting --------------------------------- \\
    void ShootCheck()
    {
        currentDelay -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!canShoot)
            {
                if (currentDelay <= 0)
                {
                    canShoot = true;
                    Shoot();
                }
            }
            else Shoot();
        }
    }
    void Shoot()
    {
        if (canShoot)
        {
            canShoot = false;
            currentDelay = reloadTime;

            GameObject round = Instantiate(bullet);
            BulletScript shell = round.GetComponent<BulletScript>();
            round.transform.position = muzzle.transform.position;
            round.transform.rotation = muzzle.transform.rotation;
            shell.startPos = muzzle.transform.position;
            shell.rb.velocity = muzzle.transform.up * round.GetComponent<BulletScript>().speed;
            shell.damage = damageValue;

            Physics2D.IgnoreCollision(round.GetComponent<Collider2D>(), tankColliders.GetComponent<Collider2D>());
        }
    }

    // -------------------------------- MISC ------------------------------- \\

    void CheckValor()
    {
        valor.text = "Valor: " + valorPoints.ToString();
        GM.totalValor = valorPoints;
    }
}
