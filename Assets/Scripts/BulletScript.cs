using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float maxDistance = 25;
    public float speed = 10;
    public float damage;

    public Vector2 startPos;
    private float traveledDistance = 0;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Init()
    {

    }

    // Update is called once per frame
    void Update()
    {
        traveledDistance = Vector2.Distance(transform.position, startPos);
        if (traveledDistance >= maxDistance)
        {
            disableBullet();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        disableBullet();
    }

    void disableBullet()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }
}
