using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimController : MonoBehaviour
{
    public GameObject target;
    float rotationSpeed = 10f;
    public GameObject chasis;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       // TurretRotate(); // currently not working but not nessasary for first playable
    }

    void TurretRotate()
    {
        Vector2 relativePos = target.transform.position - transform.position;
        float angle = Mathf.Atan2(relativePos.x, relativePos.y) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, rotationSpeed * Time.deltaTime);
    }
}
