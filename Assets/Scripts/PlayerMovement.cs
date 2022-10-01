using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float speed = 1;
    float rotationSpeed = 25;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        TankMovement();
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
    }
}
