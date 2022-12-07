using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    public GameObject Player;
    private Vector3 pos;
    private CamShake camShake;

    // Start is called before the first frame update
    void Start()
    {
        camShake = gameObject.GetComponent<CamShake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!camShake.tweening)
        {
            if (Player.transform.position.y > transform.position.y)
            {
                transform.position = Player.transform.position;
                pos = new Vector3(transform.position.x, transform.position.y, -10);
                transform.position = pos;
            }
            else
            {
                pos = new Vector3(Player.transform.position.x, transform.position.y, -10);
                transform.position = pos;
            }
        }
    }
}
