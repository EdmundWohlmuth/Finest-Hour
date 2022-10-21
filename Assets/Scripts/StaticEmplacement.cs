using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEmplacement : MonoBehaviour
{
    // rotation init
    public GameObject Player;
    private float rotationSpeed = 0.5f;
    public GameObject valor;

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

    //stats
    public int damage;
    int health = 15;

    // Damage flash
    public GameObject Dmgflash;
    public SpriteRenderer ren;
    public Color dmgColor;
    public Color baseColor;


    // Start is called before the first frame update
    void Start()
    {
        ren.color = baseColor;
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
        if (dist <= 7)
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
        angle = Mathf.Clamp(angle, minValue, maxValue);

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        Quaternion current = transform.localRotation;

        transform.localRotation = Quaternion.Slerp(current, rotation, rotationSpeed * Time.deltaTime);
    }

    void AttackCheck()
    {
        currentDelay -= Time.deltaTime;
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

    void Attack()
    {
        if (canTarget && Player.transform.position.y < transform.position.y)
        {
            canShoot = false;
            currentDelay = reloadTime;

            GameObject round = Instantiate(bullet);
            round.transform.position = muzzle.transform.position;
            round.transform.rotation = muzzle.transform.rotation;
            round.GetComponent<BulletScript>().startPos = muzzle.transform.position;
            round.GetComponent<BulletScript>().speed = 8f;
            round.GetComponent<BulletScript>().rb.velocity = -muzzle.transform.up * round.GetComponent<BulletScript>().speed;
            round.GetComponent<BulletScript>().damage = damage;

           // Physics2D.IgnoreCollision(round.GetComponent<Collider2D>(), tankColliders.GetComponent<Collider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            int damage = collision.gameObject.GetComponent<BulletScript>().damage;
            TakeDamage(damage);
            StartCoroutine(ShowDamage());
        }
    }

    void TakeDamage(int damage)
    {       
        health -= damage;
        if (health <= 0)
        {
            health = 0;
            InstantiateValor();
            Destroy(tankColliders);
        }

        Debug.Log(health);
    }

    void InstantiateValor()
    {
        for (int i = 0; i < 3; i++)
        {
            GameObject Valor = Instantiate(valor);
            Valor.transform.position = transform.position;
        }
    }

    IEnumerator ShowDamage()
    {
        ren.color = dmgColor;
        yield return new WaitForSeconds(0.5f);
        ren.color = baseColor;
    }
}
