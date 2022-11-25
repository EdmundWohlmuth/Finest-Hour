using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticEmplacement : MonoBehaviour
{
    // rotation init
    public GameObject Player;
    private float rotationSpeed = 0.5f;
    public GameObject valor;
    Vector3 forward;
    float dist;

    // Audio
    public AudioSource gunSource;
    public GameObject audioManager;
    private AudioManager AM;

    //shooting init
    public GameObject bullet;
    public float reloadTime = 1;
    public GameObject muzzle;
    public GameObject barrel;
    public GameObject flash;

    private bool canTarget = false;
    bool canShoot = true;
    public GameObject bodyCollider;
    float currentDelay = 0;

    //stats
    public int damage;
    int health = 15;

    // Damage flash
    public GameObject Dmgflash;
    public SpriteRenderer ren;
    public Color dmgColor;
    public Color baseColor;

    public enum Facing
    {
        down,
        right,
        left
    }
    public Facing direction;


    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        ren.color = baseColor;

        audioManager = GameObject.Find("GameManager/AudioManager");
        AM = audioManager.GetComponent<AudioManager>();
    }

    // Update is called once per frame
    void Update()
    {
        DistanceCheck();
        AimAtPlayer();
        AttackCheck();
    }

    void DistanceCheck() // determins if player is close enough to target
    {
        dist = Vector3.Distance(Player.transform.position, transform.position); //determin distance from player
        if (dist <= 7)
        {
            if (direction == Facing.down)
            {
                if (Player.transform.position.y > transform.position.y)
                {
                    canTarget = false;
                }
                else canTarget = true;
            }
            else if (direction == Facing.right)
            {
                if (Player.transform.position.x < transform.position.x)
                {
                    canTarget = false;
                }
                else canTarget = true;
            }
            else if (direction == Facing.left)
            {
                if (Player.transform.position.x > transform.position.x)
                {
                    canTarget = false;
                }
                else canTarget = true;
            }
        }
    }

    void AimAtPlayer() // becasue turret can be facing diffrent directions enum set from inspector sets clamps for rotaions
    {        
        barrel.transform.up = (Player.transform.position - transform.position) * -1;
        forward = barrel.transform.up;        

        // clamp rotation
        if (direction == Facing.down)
        {
            if (forward.x > 0.45f && forward.y < 0.90f)
            {
                forward.x = 0.45f;
                forward.y = 0.90f;
            }
            else if (forward.x < -0.45f && forward.y < 0.90f)
            {
                forward.x = -0.45f;
                forward.y = 0.90f;
            }
        }
        else if (direction == Facing.right)
        {
            if (forward.x > -0.90f && forward.y > 0.45f)
            {
                forward.x = -0.90f;
                forward.y = 0.45f;
            }
            else if (forward.x > -90f && forward.y < -0.45f)
            {
                forward.x = -0.90f;
                forward.y = -0.45f;
            }
        }
        else if (direction == Facing.left)
        {
            if (forward.x < 0.90f && forward.y > 0.45f)
            {
                forward.x = 0.90f;
                forward.y = 0.45f;
            }
            else if (forward.x < 90f && forward.y < -0.45f)
            {
                forward.x = 0.90f;
                forward.y = -0.45f;
            }

        }
        barrel.transform.up = forward;       
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
        if (canTarget)
        {
            canShoot = false;
            currentDelay = reloadTime;

            // initialize bullet
            GameObject round = Instantiate(bullet);
            round.transform.position = muzzle.transform.position;
            round.transform.rotation = muzzle.transform.rotation;
            round.GetComponent<BulletScript>().startPos = muzzle.transform.position;
            round.GetComponent<BulletScript>().speed = -8f;
            round.GetComponent<BulletScript>().rb.velocity = muzzle.transform.up * round.GetComponent<BulletScript>().speed;
            round.GetComponent<BulletScript>().damage = damage;

            // sfx
            StartCoroutine(muzzelFlash());
            AM.PlayGunSoundH(gunSource);

           // Physics2D.IgnoreCollision(round.GetComponent<Collider2D>(), tankColliders.GetComponent<Collider2D>());
        }
    }
    IEnumerator muzzelFlash()
    {
        flash.SetActive(true);
        yield return new WaitForSeconds(0.13f);
        flash.SetActive(false);
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
            Destroy(bodyCollider);
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
