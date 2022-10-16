using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TakeDamage : MonoBehaviour
{
    public GameObject chasis;
    public Color dmgColor;
    public Color baseColor;
    private SpriteRenderer render;

    public int currentHealth;
    public int maxHealth;

    public GameObject health;
    public Slider healthBar;
    public GameObject uIManager;
    public UIManager UI;

    // Start is called before the first frame update
    void Start()
    {
        render = chasis.GetComponent<SpriteRenderer>();
        currentHealth = GetComponent<PlayerMovement>().maxHealth;
        maxHealth = GetComponent<PlayerMovement>().maxHealth;
        uIManager = GameObject.Find("GameManager/UIManager");
        UI = uIManager.GetComponent<UIManager>();

        // get health ui
        health = GameObject.Find("GameManager/UIManager/Gameplay/HealthBar");
        healthBar = health.GetComponent<Slider>();
        healthBar.maxValue = maxHealth;
        healthBar.value = healthBar.maxValue;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Explosion")
        {
            int damageDelt;
            damageDelt = collision.GetComponent<BulletScript>().damage;

            ReduceHealth(damageDelt);
            StartCoroutine(ShowDamage());
        }
    }
    
    IEnumerator ShowDamage()
    {
        render.color = dmgColor;
        yield return new WaitForSeconds(0.5f);
        render.color = baseColor;
    }

    void ReduceHealth(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            UI.LooseState();
        }
        else
        {
            healthBar.value = currentHealth;
        }
    }
}
