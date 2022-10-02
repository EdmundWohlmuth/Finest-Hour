using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EInfantry : MonoBehaviour
{
    Vector3 startPos;
    Vector3 fleePoint;

    public GameObject Player;
    bool firstScare = true;
    float randValueX;
    float randValueY;

    public float speed = 5;
    public float waypointRefreshTime = 10;
    float waypointRefresh = 10;

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
             
    }

}
