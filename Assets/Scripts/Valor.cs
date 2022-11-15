using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Valor : MonoBehaviour
{
    public GameObject Player;
    private PlayerMovement PC;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("Player");
        PC = Player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3 (0, 0, 90) * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PC.valorPoints += (1 * PC.valorMultiplier);
            Destroy(gameObject);
        }
    }
}
