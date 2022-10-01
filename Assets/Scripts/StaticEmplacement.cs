using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEmplacement : MonoBehaviour
{
    // rotation init
    public GameObject Player;
    private float rotationSpeed = 0.5f;


    public float minValue;
    public float maxValue;

    //shooting init
    public GameObject bullet;
    public float reloadTime = 1;
    public GameObject muzzle;

    private bool canTarget = false;
    bool canShoot = true;
    public GameObject tankColliders;
    float currentDelay = 0;

    public int damage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DistanceCheck();
        AttackCheck();
    }

    void DistanceCheck()
    {
        float dist = Vector3.Distance(Player.transform.position, transform.position); //determin distance from player
        if (dist <= 6)
        {
            canTarget = true;
            AimAtPlayer();
        }
        else canTarget = false;
    }

    void AimAtPlayer()
    {
        Vector2 relativePos = Player.transform.position - transform.position;
        float angle = Mathf.Atan2(relativePos.x, relativePos.y) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, rotationSpeed * Time.deltaTime);
    }

    void AttackCheck()
    {
        currentDelay -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!canShoot)
            {
                if (currentDelay <= 0)
                {
                    canShoot = true;
                    Attack();
                }
            }
            else Attack();
        }
    }

    void Attack()
    {
        if (canTarget)
        {
            canShoot = false;
            currentDelay = reloadTime;

            GameObject round = Instantiate(bullet);
            round.transform.position = muzzle.transform.position;
            round.transform.rotation = muzzle.transform.rotation;
            round.GetComponent<BulletScript>().startPos = muzzle.transform.position;
            round.GetComponent<BulletScript>().speed = 5f;
            round.GetComponent<BulletScript>().rb.velocity = muzzle.transform.up * round.GetComponent<BulletScript>().speed;

            Physics2D.IgnoreCollision(round.GetComponent<Collider2D>(), tankColliders.GetComponent<Collider2D>());

            round.GetComponent<BulletScript>().damage = damage;
        }
    }
}
