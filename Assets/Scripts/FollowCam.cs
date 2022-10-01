using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject Player;
    private Vector3 pos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.y > transform.position.y)
        {
            transform.position = Player.transform.position;
            pos = new Vector3(transform.position.x, transform.position.y,-10);
            transform.position = pos;
        }
    }
}
