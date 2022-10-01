using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseAim : MonoBehaviour
{
    public Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MoveTarget();
        Shoot();

    }

    void MoveTarget()
    {
        // Debug.Log(mainCamera.ScreenToViewportPoint(Input.mousePosition));
        Vector2 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        transform.position = mousePosition;
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

        }
    }
}

