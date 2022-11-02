using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour
{
    [Header("Refreces")]
    public GameObject player;
    public GameObject bullet;
    public GameObject turret;
    public GameObject muzzle;
    public GameObject barrier;
    public GameObject valor;
    public GameObject flash;

    [SerializeField]
    int rotationSpeed;
    [SerializeField]
    int turretRotationSpeed;
    [SerializeField]
    float speed;
    [SerializeField]
    int damageValue;
    [SerializeField]
    int health;

    float currentDelay;
    bool canShoot;
    float reloadTime = 1f;

    private Vector3 lastKnownPos;
    public GameObject chasis;
    public Color dmgColor;
    public Color baseColor;
    private SpriteRenderer render;

    enum states
    {
        safe,
        danger,
        chase
    }
    states state;

    // Start is called before the first frame update
    void Start()
    {
        render = chasis.GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        barrier = GameObject.Find("Main Camera/Collider");
        Physics2D.IgnoreCollision(chasis.GetComponent<Collider2D>(), barrier.GetComponent<Collider2D>());       
        turret.transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        turret.transform.position = transform.position;
        StateCheck();

        switch (state)
        {
            case states.safe:
                break;
            case states.danger:

                Movement();
                TurretRotate();
                Attack();
                lastKnownPos = player.transform.position;

                break;
            case states.chase:

                Movement();

                break;
        }
    }

    void StateCheck()
    {
        if (state == states.safe &&
            Vector3.Distance(transform.position, player.transform.position) < 9) state = states.danger;

        else if (state == states.danger && 
            Vector3.Distance(transform.position, player.transform.position) < 9) state = states.chase;

        else state = states.safe;
    }

    void Movement()
    {
        if (player.transform.position.x > transform.position.x)
        {
            float rotation = 1f * rotationSpeed;
            transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        }
        if (player.transform.position.x < transform.position.x)
        {
            float rotation = -1f * rotationSpeed;
            transform.Rotate(Vector3.forward * rotation * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, player.transform.position) < 4) // if player is too close back off...
        {
            transform.position += transform.up * speed * Time.deltaTime;
        }
        else
        {
            transform.position += -transform.up * speed * Time.deltaTime;       // ...otherwise close the gap between the player
        }

    }

    void TurretRotate()
    {
        Vector2 relativePos = player.transform.position - turret.transform.position;
        float angle = Mathf.Atan2(relativePos.x, relativePos.y) * Mathf.Rad2Deg;

        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.back);
        Quaternion current = turret.transform.localRotation;

        turret.transform.localRotation = Quaternion.Slerp(current, rotation, turretRotationSpeed * Time.deltaTime);
    }

    void Attack()
    {
        currentDelay -= Time.deltaTime;
        if (!canShoot)
        {
            if (currentDelay <= 0)
            {
                canShoot = true;
                Shoot();
            }
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
            round.GetComponent<BulletScript>().speed = 5f;
            round.GetComponent<BulletScript>().rb.velocity = muzzle.transform.up * round.GetComponent<BulletScript>().speed;
            round.GetComponent<BulletScript>().damage = damageValue;

            Physics2D.IgnoreCollision(round.GetComponent<Collider2D>(), chasis.GetComponent<Collider2D>());
            StartCoroutine(muzzelFlash());
        }
    }

    void ReduceHealth(int damageDelt)
    {
        health -= damageDelt;
        if (health <= 0)
        {
            InstantiateValor();
            Destroy(gameObject);
            Destroy(turret);
        }
        Debug.Log(health);
    }

    void Search()
    {
        // isSearching = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            int damageDelt;
            damageDelt = collision.GetComponent<BulletScript>().damage;

            ReduceHealth(damageDelt);
            StartCoroutine(ShowDamage());
        }
    }

    IEnumerator ShowDamage()
    {
        render.color = dmgColor;
        yield return new WaitForSeconds(0.5f);
        render.color = baseColor;
    }

    IEnumerator SearchCountDown()
    {
        yield return new WaitForSeconds(5f);
        // isSearching = false;
    }

    void InstantiateValor()
    {
        for (int i = 0; i <= 5; i++)
        {
            GameObject Valor = Instantiate(valor);
            Valor.transform.position = transform.position;
        }
    }

    IEnumerator muzzelFlash()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(0.13f);
        flash.SetActive(false);
    }
}
