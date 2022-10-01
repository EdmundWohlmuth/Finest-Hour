using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterObject : MonoBehaviour
{
    public enum Object
    {
        sandbag,
        tanktrap
    }
    public Object m_Object;

    private void OnCollisionEnter2D(Collision2D collision)
    {       
        if (m_Object == Object.sandbag && collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Explosion")
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion") {

            Destroy(gameObject);
        }
    }
}
