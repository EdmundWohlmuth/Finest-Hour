using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float reloadTime = 1f;
    public GameObject muzzle;

    bool canShoot = true;
    public GameObject tankColliders;
    float currentDelay = 0;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!canShoot)
            {
                currentDelay -= Time.deltaTime;
                if (currentDelay <= 0)
                {
                    canShoot = true;
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
            round.transform.position = muzzle.transform.position;
            round.transform.localRotation = muzzle.transform.localRotation;
            round.GetComponent<BulletScript>().startPos = transform.position;
            round.GetComponent<BulletScript>().rb.velocity = transform.up * round.GetComponent<BulletScript>().speed;

            Physics2D.IgnoreCollision(round.GetComponent<Collider2D>(), tankColliders.GetComponent<Collider2D>());
        }
    }
}
