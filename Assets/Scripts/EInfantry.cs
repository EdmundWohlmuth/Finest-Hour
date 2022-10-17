using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EInfantry : MonoBehaviour
{
    Vector3 startPos;
    Vector3 fleePoint;

    public GameObject Player;
    public GameObject valor;
    bool firstScare = true;
    float randValueX;
    float randValueY;

    public float speed = 1;
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
        if (Vector3.Distance(transform.position, Player.transform.position) < 5)
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
        
    }

    void BehaviorDanger()
    {
        if (firstScare == true)
        {
            Debug.Log("Inital scare");
            firstScare = false;
            FindFleePos();
            Movement();
        }
        runningTime += Time.deltaTime;

        if (Vector3.Distance(fleePoint, transform.position) < 1 || runningTime >= runningTimeMax)
        {
            runningTime = 0;
            FindFleePos();
            Movement();

        }
        
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
        Debug.Log("flee point: " + fleePoint);
        Debug.Log("current pos: " + transform.position);
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
        randValueX = Random.Range(transform.position.x -10, transform.position.x + 10);
        randValueY = Random.Range(transform.position.y - 10, transform.position.y + 10);
    }

    void InstantiateValor()
    {
        GameObject Valor = Instantiate(valor);
        Valor.transform.position = transform.position;
    }

}


