using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;
    float speed = 1;
    float rotationSpeed = 25;

    public int valorPoints;
    public TextMeshProUGUI valor;

    public float fuelValue;
    public TextMeshProUGUI gas;

    // Start is called before the first frame update
    void Start()
    {
        fuelValue = gameManager.maxFuel;
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
        while (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
        {
            
        }
    }
}
