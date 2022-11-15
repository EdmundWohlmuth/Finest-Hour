using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterObject : MonoBehaviour
{
    public Sprite destoryedSandbag;

    public enum Object
    {
        sandbag,
        tanktrap
    }
    public Object m_Object;

    private void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if (m_Object == Object.sandbag && collision.gameObject.tag == "Player")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = destoryedSandbag;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
        else if (collision.gameObject.tag == "Explosion")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = destoryedSandbag;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (m_Object == Object.sandbag && collision.gameObject.tag == "Explosion")
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = destoryedSandbag;
            Destroy(gameObject.GetComponent<BoxCollider2D>());
        }
        else if (collision.gameObject.tag == "Explosion") {

            Destroy(gameObject);
        }
    }
}
