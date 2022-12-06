using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public float maxDistance = 5;
    public float speed = 10;
    public int damage;

    public Vector2 startPos;
    private float traveledDistance = 0;

    public Rigidbody2D rb;
    public GameObject explosion;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        traveledDistance = Vector2.Distance(transform.position, startPos);
        if (traveledDistance >= maxDistance)
        {
            explosion.transform.position = transform.position;
            Instantiate(explosion);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Valor")
        {
            CreateExplosion();
            disableBullet();
        }
    }

    void disableBullet()
    {
        rb.velocity = Vector2.zero;
        gameObject.SetActive(false);
    }

    void CreateExplosion()
    {
        explosion.transform.position = transform.position;
        Instantiate(explosion);
    }
}
