using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bullet;
    public float reloadTime = 1;
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
            round.transform.position = muzzle.transform.position;
            round.transform.rotation = muzzle.transform.rotation;
            round.GetComponent<BulletScript>().startPos = muzzle.transform.position;
            round.GetComponent<BulletScript>().rb.velocity = muzzle.transform.up * round.GetComponent<BulletScript>().speed;

            Physics2D.IgnoreCollision(round.GetComponent<Collider2D>(), tankColliders.GetComponent<Collider2D>());
        }
    }
}
