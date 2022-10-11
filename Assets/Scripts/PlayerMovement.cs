using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameObject gameManager;
    private GameManager GM;
    public GameObject uIManager;
    private UIManager UI;

    public float speed = 1;
    public float rotationSpeed = 25;

    public int valorPoints;
    public TextMeshProUGUI valor;

    public int maxHealth;

    public int damageValue;

    public float maxFuel;
    public float currentFuel;
    public GameObject gas;
    public Slider gasMeter;

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

        // set player values
        maxHealth = GM.maxHealth;
        damageValue = GM.damageValue;
        currentFuel = GM.maxFuel;
    }

    // Update is called once per frame
    void Update()
    {
        TankMovement();
        SpendFuel();       
    }

    // ------------------------ Tank Chasis Movement ------------------------- \\
    void TankMovement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.D))
        {
            float rotation = -1f * rotationSpeed;
            transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            float rotation = 1f * rotationSpeed;
            transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Application.Quit(0);
        }
    }

    void SpendFuel()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            currentFuel = currentFuel -= Time.deltaTime;

            if (currentFuel <= 0)
            {
                currentFuel = 0;
                UI.LooseState();
            }
            else
            {
                gasMeter.value = currentFuel;
            }           
        }
    }
}
