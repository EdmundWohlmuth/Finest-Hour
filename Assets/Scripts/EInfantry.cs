using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EInfantry : MonoBehaviour
{
    Vector3 startPos;
    Vector3 fleePoint;

    public GameObject barrier;
    public GameObject Player;
    public GameObject valor;
    public GameObject scareSprite;
    bool firstScare = true;
    float randValueX;
    float randValueY;

    public float speed = 0.01f;
    float runningTime = 0;
    float runningTimeMax = 10;

    enum State
    {
        Safe,
        Danger
    }
    private State state;

    // Start is called before the first frame update
    void Start()
    {
        barrier = GameObject.Find("Main Camera/Collider");
        Physics2D.IgnoreCollision(GetComponent<Collider2D>(), barrier.GetComponent<Collider2D>());
        startPos = transform.position;
        state = State.Safe;
    }

    // Update is called once per frame
    void Update()
    {
        SetState();
        RunBehavior();

    }

    // --------------------------------- States --------------------------- \\

    void SetState()
    {
        if (Vector3.Distance(transform.position, Player.transform.position) <= 5)
        {
            state = State.Danger;
        }
        else state = State.Safe;
    }

    void RunBehavior()
    {
        if (state == State.Safe)
        {
            BehaviorSafe();
        }
        else if (state == State.Danger)
        {
            BehaviorDanger();
        }
    }

    void BehaviorSafe()
    {
        transform.position = Vector2.MoveTowards(transform.position, startPos, speed * Time.deltaTime);
    }

    void BehaviorDanger()
    {
        if (firstScare == true)
        {
            firstScare = false;
            FindFleePos();
            StartCoroutine(ShowFear());
        }
        runningTime += Time.deltaTime;

        if (Vector3.Distance(fleePoint, transform.position) < 1 || runningTime >= runningTimeMax)
        {
            runningTime = 0;
            FindFleePos();
        }
        Movement();
    }

    // ------------------------------- Movement --------------------------- \\

    void FindFleePos()
    {       
        SetRandom();
        fleePoint = new Vector2(randValueX, randValueY);
    }

    void Movement()
    {
        transform.position = Vector2.MoveTowards(transform.position, fleePoint, speed * Time.deltaTime);
    }

    // ------------------------------ Take Damage ------------------------- \\

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            InstantiateValor();
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InstantiateValor();
            Destroy(gameObject);
        }
    }

    void TakeDamage()
    {
        Debug.Log("Infantry took Damage");
    }

    // ------------------------------ other ------------------------------- \\
    void SetRandom()
    {
        randValueX = Random.Range(transform.position.x -3, transform.position.x + 3);
        randValueY = Random.Range(transform.position.y - 3, transform.position.y + 3);
    }

    void InstantiateValor()
    {
        GameObject Valor = Instantiate(valor);
        Valor.transform.position = transform.position;
    }

    IEnumerator ShowFear()
    {
        scareSprite.SetActive(true);
        yield return new WaitForSeconds(0.25f);
        scareSprite.SetActive(false);
    }

}


