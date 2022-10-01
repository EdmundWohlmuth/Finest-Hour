using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeDamage : MonoBehaviour
{
    public GameObject chasis;
    public Color dmgColor;
    public Color baseColor;
    private SpriteRenderer render;

    // Start is called before the first frame update
    void Start()
    {
        render = chasis.GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            ReduceHealth();
            StartCoroutine(ShowDamage());
        }
    }
    
    IEnumerator ShowDamage()
    {
        render.color = dmgColor;
        yield return new WaitForSeconds(1f);
        render.color = baseColor;
    }

    void ReduceHealth()
    {
        Debug.Log("Damage Taken");
    }
}
